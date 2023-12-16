namespace Spread.Connect.Application.Admin.Actions.Users.Commands.SpreadUserResetPassword;

public class SpreadUserResetPasswordValidator : AbstractValidator<SpreadUserResetPasswordCommand>
{
    public SpreadUserResetPasswordValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(Constants.FieldSize.Email);
    }
}
