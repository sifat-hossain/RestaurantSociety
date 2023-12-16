namespace Restaurant.Society.Application.Admin.Actions.Roles.Commands.DeleteRole;

public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleValidator()
    {
        RuleFor(r => r.RoleId)
            .NotEmpty();
    }
}
