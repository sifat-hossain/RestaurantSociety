using FluentValidation;

namespace Restaurant.Society.Application.Auth.Actions.Users.Commands.RefreshToken;

public class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenValidator()
    {
        RuleFor(r => r.RefreshToken)
            .NotEmpty();
    }
}
