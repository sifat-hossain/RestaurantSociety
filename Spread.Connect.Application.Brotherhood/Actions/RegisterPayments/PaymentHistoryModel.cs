using Spread.Connect.Domain.Brotherhood.Entities.Payments;
using System.Linq.Expressions;

namespace Spread.Connect.Application.Brotherhood.Actions.RegisterPayments;

public class PaymentHistoryModel
{
    /// <summary>
    /// Gets or sets the name associated with the payment.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the phone number associated with the payment.
    /// </summary>
    public decimal PaymentAmount { get; set; }

    /// <summary>
    /// Gets or sets the email associated with the payment.
    /// </summary>
    public int StoreAmount { get; set; }

    /// <summary>
    /// Gets or sets the amount of the payment.
    /// </summary>
    public string? TrxId { get; set; }

    /// <summary>
    /// Payment campaign
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Payment references
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Payment references
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Payment references
    /// </summary>
    public string? PaymentLink { get; set; }

    /// <summary>
    /// Payment references
    /// </summary>
    public string? Vendor { get; set; }

    /// <summary>
    /// Payment references
    /// </summary>
    public string? Campaign { get; set; }

    /// <summary>
    /// Payment references
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// Payment references
    /// </summary>
    public DateTime DateTime { get; set; }

    public static Expression<Func<PaymentHistory, PaymentHistoryModel>> Projection
    {
        get
        {
            return paymentHistory => new PaymentHistoryModel
            {
                UserId = paymentHistory.UserId,
                TrxId = paymentHistory.TrxId,
                Name = paymentHistory.Name,
                Email = paymentHistory.Email,
                Phone = paymentHistory.Phone,
                PaymentLink = paymentHistory.PaymentLink,
                Vendor = paymentHistory.Vendor,
                Campaign = paymentHistory.Campaign,
                Reference = paymentHistory.Reference,
                DateTime = paymentHistory.DateTime
            };
        }
    }


    public static PaymentHistoryModel Create(PaymentHistory entity)
    {
        return Projection.Compile().Invoke(entity);
    }
}
