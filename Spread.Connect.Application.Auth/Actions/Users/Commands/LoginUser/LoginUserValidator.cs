using FluentValidation;

namespace Spread.Connect.Application.Auth.Actions.Users.Commands.LoginUser;

public class LoginUserValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserValidator()
    {
        RuleFor(r => r.Username)
            .NotEmpty();

        RuleFor(r => r.Username)
            .NotEmpty();
    }
}
