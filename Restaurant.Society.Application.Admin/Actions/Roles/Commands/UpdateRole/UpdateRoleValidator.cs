namespace Restaurant.Society.Application.Admin.Actions.Roles.Commands.UpdateRole;

public class UpdateRoleValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleValidator()
    {
        RuleFor(r => r.RoleId)
            .NotEmpty();

        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(Constants.FieldSize.Name);
    }
}
