namespace Spread.Connect.Application.Admin.Actions.Roles.Commands.UpdateRole;

/// <summary>
/// Represents logic for UpdateRoleCommand
/// </summary>
public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand>
{
    private readonly IAdminDbContext _adminDbContext;

    public UpdateRoleHandler(IAdminDbContext adminDbContext)
    {
        _adminDbContext = adminDbContext;
    }

    public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        Role dbRole = await _adminDbContext.Role
           .FirstOrDefaultAsync(r => r.RoleId == request.RoleId);

        if (dbRole == null)
        {
            throw new NotFoundException(nameof(Role), request.RoleId);
        }

        dbRole.Name = request.Name;
        dbRole.Inactive = request.Inactive;

        await _adminDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
