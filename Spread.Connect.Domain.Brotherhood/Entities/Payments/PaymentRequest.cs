namespace Spread.Connect.Domain.Brotherhood.Entities.Payments;

public class PaymentRequest : BasePaymentEntity
{
    /// <summary>
    /// Unique identifire
    /// </summary>
    public Guid PaymentRequestId { get; set; }

    /// <summary>
    /// Userid of of payee
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// The amount of money paid by the user
    /// </summary>
    public decimal PaymentAmount { get; set; }

    /// <summary>
    /// The transaction ID of the payment
    /// </summary>
    public string TrxId { get; set; }
}
