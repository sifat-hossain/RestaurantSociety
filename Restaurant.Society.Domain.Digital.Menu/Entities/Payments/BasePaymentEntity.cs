namespace Spread.Connect.Domain.Brotherhood.Entities.Payments;

public class BasePaymentEntity
{
    // Optional property to capture the name of the user who made the payment
    public string? Name { get; set; }

    // Optional property to capture the email address of the user who made the payment
    public string? Email { get; set; }

    // Required property to capture the phone number of the user who made the payment
    public string Phone { get; set; }

    // Optional property to store a link to the payment page where the user made the payment
    public string? PaymentLink { get; set; }

    // Optional property to store the name of the vendor
    public string? Vendor { get; set; }

    // Optional property to store the name of the campaign
    public string? Campaign { get; set; }

    // Optional property to store a reference related to the payment
    public string? Reference { get; set; }

    // The date and time when the payment was made
    public DateTime DateTime { get; set; }
}
