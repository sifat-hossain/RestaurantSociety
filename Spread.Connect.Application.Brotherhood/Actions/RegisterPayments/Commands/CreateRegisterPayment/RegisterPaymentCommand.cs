using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Spread.Connect.Application.Brotherhood.Actions.RegisterPayments.Commands.CreateRegisterPayment;

/// <summary>
/// This class represents a model for registering payment information.
/// </summary>
public class RegisterPaymentCommand : IRequest<RegisterPaymentModel>
{

    /// <summary>
    /// Gets or sets the name associated with the payment.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the phone number associated with the payment.
    /// </summary>
    [Required]
    public string Phone { get; set; }

    /// <summary>
    /// Gets or sets the email associated with the payment.
    /// </summary>
    /// 
    [Required]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the amount of the payment.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Payment campaign
    /// </summary>
    public string? Campaign { get; set; }

    /// <summary>
    /// Payment references
    /// </summary>
    public string? Reference { get; set; }
}

