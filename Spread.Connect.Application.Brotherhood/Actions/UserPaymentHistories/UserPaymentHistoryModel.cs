using Spread.Connect.Domain.Brotherhood.Entities.Payments;
using System.Linq.Expressions;

namespace Spread.Connect.Application.Brotherhood.Actions.UserPaymentHistories;

public class UserPaymentHistoryModel
{
    #region properties
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    #endregion
    public static Expression<Func<PaymentHistory, UserPaymentHistoryModel>> Projection
    {
        get
        {
            return payments => new UserPaymentHistoryModel
            {
                Id = payments.PaymentHistoryId,
                //FirstName = user.FirstName,
                //Surname = user.Surname,
                Email = payments.Email
            };
        }
    }

    public static UserPaymentHistoryModel Create(PaymentHistory entity)
    {
        return Projection.Compile().Invoke(entity);
    }
}
