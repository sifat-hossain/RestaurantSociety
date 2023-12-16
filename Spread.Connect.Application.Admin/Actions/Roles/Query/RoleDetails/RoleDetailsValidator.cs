namespace Spread.Connect.Application.Admin.Actions.Roles.Query.RoleDetails;

public class RoleDetailsValidator : AbstractValidator<RoleDetailsQuery>
{
    public RoleDetailsValidator()
    {
        RuleFor(r => r.RoleId)
            .NotEmpty();
    }
}
