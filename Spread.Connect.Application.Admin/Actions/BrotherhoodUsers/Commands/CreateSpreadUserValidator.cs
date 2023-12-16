namespace Spread.Connect.Application.Admin.Actions.BrotherhoodUsers.Commands;

public class CreateSpreadUserValidator : AbstractValidator<CreateSpreadUserCommand>
{
    public CreateSpreadUserValidator()
    {
        RuleFor(r => r.UserName)
            .NotEmpty()
            .MaximumLength(Constants.FieldSize.Name);

        RuleFor(r => r.Phone)
            .MaximumLength(Constants.FieldSize.PhoneNumber)
            .NotEmpty();

        RuleFor(r => r.NID)
            .NotEmpty();

        RuleFor(r => r.Email)
            .EmailAddress()
            .MaximumLength(Constants.FieldSize.Email);

        //RuleFor(r => r.Roles)
        //    .Cascade(CascadeMode.StopOnFirstFailure)
        //    .Must(roles => roles != null && roles.Any())
        //    .WithMessage("At least one role must be selected.");


    }
}
