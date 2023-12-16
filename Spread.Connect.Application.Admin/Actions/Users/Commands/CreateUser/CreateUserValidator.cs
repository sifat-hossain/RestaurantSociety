namespace Spread.Connect.Application.Admin.Actions.Users.Commands.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(r => r.FirstName)
            .NotEmpty()
            .MaximumLength(Constants.FieldSize.Name);

        RuleFor(r => r.Surname)
            .NotEmpty()
            .MaximumLength(Constants.FieldSize.Name);

        RuleFor(r => r.UserName)
            .NotEmpty()
            .MaximumLength(Constants.FieldSize.Name);

        RuleFor(r => r.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(Constants.FieldSize.Email);

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(Constants.FieldSize.Password)
            .Equal(c => c.ConfirmPassword);
    }
}
