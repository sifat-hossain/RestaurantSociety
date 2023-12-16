namespace Spread.Connect.Application.Admin.Actions.Users.Commands.DisableUser;

public class DisableUserValidator : AbstractValidator<DisableUserCommand>
{
    public DisableUserValidator()
    {
        RuleFor(r => r.UserId)
            .NotEmpty();
    }
}
