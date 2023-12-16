using FluentValidation;
using Spread.Connect.Application.Brotherhood.Actions.UserPaymentHistories.Commands;

namespace Spread.Connect.Application.Brotherhood.Actions.UserPaymentHistories.Query;

public class UserPaymentHistoryValidatior : AbstractValidator<UserPaymentHistoryQuery>
{
    public UserPaymentHistoryValidatior()
    {
        RuleFor(r => r.UserId)
        .NotEmpty()
        .WithMessage("User ID cannot be empty.")
        .WithErrorCode("1001");
    }
}
