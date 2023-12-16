using MediatR;
using Microsoft.Extensions.Configuration;
using Spread.Connect.Domain.Brotherhood.Entities.Payments;
using Spread.Connect.Domain.Framework.Contracts.Email;
using INotification = Spread.Connect.Application.Brotherhood.Services.INotification;

namespace Spread.Connect.Application.Brotherhood.Actions.RegisterPayments.Commands.CreatePaymentHistory;

public class PaymentHistoryHandler : IRequestHandler<PaymentHistoryCommand, PaymentHistoryModel>
{
    private readonly IConfiguration _configuration;
    private readonly IBrotherhoodDbContext _brotherhoodDbContext;
    private readonly INotification _notification;

    public PaymentHistoryHandler(IBrotherhoodDbContext brotherhoodDbContext, IConfiguration configuration, INotification notification)
    {
        _brotherhoodDbContext = brotherhoodDbContext;
        _configuration = configuration;
        _notification = notification;
    }

    public async Task<PaymentHistoryModel> Handle(PaymentHistoryCommand command, CancellationToken cancellationToken)
    {
        //Send email 
        EmailHelper emailHelper = new EmailHelper
        {
            Email = "isrukhasan@gmail.com",
            Subject = "Test Mail",
            CcEmail = "sifat1258@gmail.com",
            BccEmail = "sifat1258@gmail.com",
            Content = "Test"
        };
        //await _notification.SendEmail(emailHelper);
        //send sms
        //save info
        var executedPayments = new PaymentHistory
        {
            Name = command.Name,
            Phone = command.Phone,
            Email = command.Email,
            Campaign = command.Campaign,
            TrxId = command.TrxId,
            PaymentAmount = command.PaymentAmount,
            Vendor = command.Vendor,
            Reference = command.Reference,
            StoreAmount = command.StoreAmount,
            DateTime = Convert.ToDateTime(command.DateTime)
        };

        await _brotherhoodDbContext.PaymentHistories.AddAsync(executedPayments);
        await _brotherhoodDbContext.SaveChangesAsync(cancellationToken);

        return PaymentHistoryModel.Create(executedPayments);

    }
}
