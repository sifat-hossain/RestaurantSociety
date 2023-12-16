namespace Restaurant.Society.Application.Admin.Actions.Roles.Commands.CreateRole;

public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(Constants.FieldSize.Name);
    }
}
