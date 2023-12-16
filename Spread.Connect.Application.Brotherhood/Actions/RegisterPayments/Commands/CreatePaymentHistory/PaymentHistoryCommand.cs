using MediatR;

namespace Spread.Connect.Application.Brotherhood.Actions.RegisterPayments.Commands.CreatePaymentHistory
{
    /// <summary>
    /// need refactor
    /// </summary>
    public class PaymentHistoryCommand : IRequest<PaymentHistoryModel>
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
        public decimal StoreAmount { get; set; }

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
        public string? DateTime { get; set; }

        /// <summary>
        /// Service charge for payment gateway
        /// </summary>
        public string? ServiceCharge { get; set; }

        public string? CardNo { get; set; }
    }
}
