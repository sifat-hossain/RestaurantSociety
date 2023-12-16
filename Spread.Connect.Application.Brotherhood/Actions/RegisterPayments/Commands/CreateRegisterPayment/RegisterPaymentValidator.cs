using FluentValidation;

namespace Spread.Connect.Application.Brotherhood.Actions.RegisterPayments.Commands.CreateRegisterPayment;

public class RegisterPaymentValidator : AbstractValidator<RegisterPaymentCommand>
{
    public RegisterPaymentValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty();

        RuleFor(c => c.Phone)
            .NotEmpty()
            .Length(11);

        RuleFor(c => c.Amount)
            .NotEmpty()
            .GreaterThan(1);

        RuleFor(c => c.Campaign)
            .NotEmpty();

        RuleFor(c => c.Reference)
            .NotEmpty();

    }
}
