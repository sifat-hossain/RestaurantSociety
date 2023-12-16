using Spread.Connect.Domain.Brotherhood.Entities.Payments;
using System.Linq.Expressions;

namespace Spread.Connect.Application.Brotherhood.Actions.RegisterPayments;

/// <summary>
/// This class represents a model for registering payment information.
/// </summary>
public class RegisterPaymentModel
{
    public string result { get; set; }
    public string? payment_url { get; set; }
    public string? message { get; set; }

    public static Expression<Func<PaymentRequest, RegisterPaymentModel>> Projection
    {
        get
        {
            return registerPayment => new RegisterPaymentModel
            {


            };
        }
    }


    public static RegisterPaymentModel Create(PaymentRequest entity)
    {
        return Projection.Compile().Invoke(entity);
    }
}
