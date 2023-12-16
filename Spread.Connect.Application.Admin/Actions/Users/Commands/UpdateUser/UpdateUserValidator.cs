namespace Spread.Connect.Application.Admin.Actions.Users.Commands.UpdateUser;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidator()
    {
        RuleFor(r => r.FirstName)
            .NotEmpty()
            .MaximumLength(Constants.FieldSize.Name);

        RuleFor(r => r.Surname)
            .NotEmpty()
            .MaximumLength(Constants.FieldSize.Name);

        RuleFor(r => r.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(Constants.FieldSize.Email);
    }
}
