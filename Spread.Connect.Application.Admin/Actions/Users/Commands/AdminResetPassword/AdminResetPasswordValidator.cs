namespace Spread.Connect.Application.Admin.Actions.Users.Commands.AdminResetPassword;

public class AdminResetPasswordValidator : AbstractValidator<AdminResetPasswordCommand>
{
    public AdminResetPasswordValidator()
    {
        RuleFor(r => r.UserId)
            .NotEmpty();

        RuleFor(c => c.NewPassword)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(Constants.FieldSize.Password)
            .Equal(c => c.ConfirmPassword);
    }
}
