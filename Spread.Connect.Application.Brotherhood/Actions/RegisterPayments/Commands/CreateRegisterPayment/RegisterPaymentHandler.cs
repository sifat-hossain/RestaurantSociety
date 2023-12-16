using MediatR;
using Microsoft.Extensions.Configuration;
using Spread.Connect.Domain.Brotherhood.Dtos;
using Spread.Connect.Domain.Brotherhood.Entities.Payments;
using System.Text.Json;

namespace Spread.Connect.Application.Brotherhood.Actions.RegisterPayments.Commands.CreateRegisterPayment;

public class RegisterPaymentHandler : IRequestHandler<RegisterPaymentCommand, RegisterPaymentModel>
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly IBrotherhoodDbContext _brotherhoodDbContext;

    public RegisterPaymentHandler(IHttpClientFactory httpClientFactory, IConfiguration configuration, IBrotherhoodDbContext brotherhoodDbContext)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _brotherhoodDbContext = brotherhoodDbContext;
    }

    /// <summary>
    /// Handles the payment method
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Payment url</returns>
    public async Task<RegisterPaymentModel> Handle(RegisterPaymentCommand request, CancellationToken cancellationToken)
    {
        string? paymentUrl;

        if (Convert.ToInt16(request.Amount) <= Convert.ToInt16(_configuration["PaymentConfig:MinimumAmount"]))
        {
            return new RegisterPaymentModel
            {
                result = "false",
                message = "Payment amount must be greater than " + _configuration["PaymentConfig:MinimumAmount"]
            };
        }
        if (_configuration["PaymentConfig:IsLive"] == "true")
        {
            paymentUrl = _configuration["PaymentConfig:LiveUrl"];
        }
        else paymentUrl = _configuration["PaymentConfig:SandboxUrl"];

        var requestData = GetRequestData(request);

        var payment = new StringContent(JsonSerializer.Serialize(requestData), System.Text.Encoding.UTF8, "application/json");

        try
        {
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.PostAsync(paymentUrl, payment, cancellationToken).ConfigureAwait(false);

            var response = httpResponseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            var paymentObject = JsonSerializer.Deserialize<RegisterPaymentModel>
                (await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken));

            if (paymentObject.result == "flase")
            {
                return new RegisterPaymentModel
                {
                    payment_url = null,
                    result = paymentObject.result,
                    message = "Payment cannot be processed"
                };
            }

            var registerPaymentRequestItem = new PaymentRequest
            {
                Name = request.Name,
                PaymentAmount = request.Amount,
                TrxId = (string)requestData["tran_id"],
                DateTime = DateTime.Now,
                Email = requestData["cus_email"].ToString(),
                Phone = request.Phone,
                PaymentLink = paymentObject.payment_url,
                Campaign = request.Campaign,
                Reference = request.Reference
            };
            await _brotherhoodDbContext.PaymentRequest.AddAsync(registerPaymentRequestItem);
            await _brotherhoodDbContext.SaveChangesAsync(cancellationToken);

            return new RegisterPaymentModel
            {
                payment_url = paymentObject.payment_url,
                result = paymentObject.result,
                message = "Payment initiated"
            };
        }
        catch (Exception ex)
        {
            return new RegisterPaymentModel
            {
                payment_url = null,
                result = "Exception occured",
                message = ex.InnerException?.ToString()
            };
        }
    }

    /// <summary>
    /// Makes the payment request 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    private Dictionary<string, object> GetRequestData(RegisterPaymentCommand request)
    {
        var successurl = _brotherhoodDbContext.ApplicationSettings
            .Where(p => p.ParamName == "SuccessUrl").Select(p => p.Value).FirstOrDefault();
        var failUrl = _brotherhoodDbContext.ApplicationSettings
            .Where(p => p.ParamName == "FailUrl").Select(p => p.Value).FirstOrDefault();
        var cancelUrl = _brotherhoodDbContext.ApplicationSettings
            .Where(p => p.ParamName == "CancelUrl").Select(p => p.Value).FirstOrDefault();

        var storeId = _configuration["PaymentConfig:StoreId"];
        var signatureKey = _configuration["PaymentConfig:SignatureKey"];
        var type = _configuration["PaymentConfig:Type"];        
        var currency = _configuration["PaymentConfig:Currency"];
        var country = _configuration["PaymentConfig:Country"];
        var email = string.IsNullOrWhiteSpace(request.Email) ? _configuration["PaymentConfig:DefaultEmail"] : request.Email;
        var trx = MakeTrxId();

        var requestData = new Dictionary<string, object>
        {
            { "store_id",storeId },
            { "signature_key", signatureKey },
            { "cus_name", request.Name },
            { "cus_email",  email},
            { "cus_phone", request.Phone },
            { "cus_add1", "Dhaka" },
            { "cus_add2", "Bangladesh" },
            { "cus_city", "Dhaka" },
            { "cus_country", country },
            { "amount", request.Amount },
            { "currency", currency},
            { "success_url", successurl },
            { "fail_url", failUrl },
            { "cancel_url",cancelUrl },
            { "desc", "TEST" },
            { "type", type },
            { "tran_id", trx },
            { "opt_a", request.Campaign },
            { "opt_b", request.Reference },
            { "opt_c", string.Empty },
       };
        return requestData;
    }

    /// <summary>
    /// This makes the transactionId
    /// </summary>
    /// <returns></returns>
    private static string MakeTrxId()
    {
        var ticks = new DateTime(2016, 1, 1).Ticks;
        var ans = DateTime.Now.Ticks - ticks;
        var uniqueId = ans.ToString("x").ToUpper();
        return uniqueId;
    }
}
