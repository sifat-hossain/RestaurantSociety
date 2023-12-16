namespace Spread.Connect.Application.Admin.Actions.Users.Commands.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordValidator()
    {
        RuleFor(r => r.UserId)
            .NotEmpty();

        RuleFor(c => c.NewPassword)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(Constants.FieldSize.Password)
            .Equal(c => c.ConfirmNewPassword);
    }
}
