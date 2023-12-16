using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Spread.Connect.Application.Brotherhood.Actions.RegisterPayments;
using Spread.Connect.Application.Brotherhood.Actions.RegisterPayments.Commands.CreatePaymentHistory;
using Spread.Connect.Application.Brotherhood.Actions.RegisterPayments.Commands.CreateRegisterPayment;
using System.Net.Mime;

namespace Spread.Connect.Api.Brotherhood.Controllers;



//[ApiKeyFilter]
[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class PaymentInitiatorController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentInitiatorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [EnableCors]
    [AllowAnonymous]
    [HttpPost("registration-payment")]
    public async Task<RegisterPaymentModel> RegisterPaymentAsync(RegisterPaymentCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPost("payment-callback")]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<Unit> Callback()
    {
        var dict = new Dictionary<string, string>();

        foreach (var key in HttpContext.Request.Form.Keys)
        {
            var value = HttpContext.Request.Form[key];
            dict.Add(key, value);
        }


        var history = new PaymentHistoryCommand
        {
            Name = dict["cus_name"],
            Email = dict["cus_email"],
            Campaign = dict["opt_a"],
            Reference = dict["opt_b"],
            PaymentAmount = Convert.ToDecimal(dict["amount"]),
            StoreAmount = Convert.ToDecimal(dict["store_amount"]),
            TrxId = dict["pg_txnid"],
            Vendor = dict["card_type"],
            Phone = dict["cus_phone"],
            DateTime = dict["pay_time"],
            ServiceCharge = dict["pg_service_charge_bdt"],
            CardNo = dict["card_number"]
        };

        await _mediator.Send(history);

        return Unit.Value;
    }
}
