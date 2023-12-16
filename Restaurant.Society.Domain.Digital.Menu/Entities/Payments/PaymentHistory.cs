namespace Spread.Connect.Domain.Brotherhood.Entities.Payments;

public class PaymentHistory : BasePaymentEntity
{
    // Unique identifier for each payment history record
    public Guid PaymentHistoryId { get; set; }

    // Identifier for the user who made the payment
    public string? UserId { get; set; }

    // The amount of money paid by the user
    public decimal PaymentAmount { get; set; }

    // The amount of money that was actually received by the seller after deducting any transaction fees or other charges
    public decimal StoreAmount { get; set; }

    // The transaction ID of the payment
    public string TrxId { get; set; }

}

