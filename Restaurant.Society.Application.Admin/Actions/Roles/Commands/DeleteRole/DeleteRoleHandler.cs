using Restaurant.Society.Admin.Entities;

namespace Restaurant.Society.Application.Admin.Actions.Roles.Commands.DeleteRole;

/// <summary>
/// Represents logic for DeleteRoleCommand
/// </summary>
public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand>
{
    private readonly IAdminDbContext _adminDbContext;

    public DeleteRoleHandler(IAdminDbContext adminDbContext)
    {
        _adminDbContext = adminDbContext;
    }

    public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        Role dbRole = await _adminDbContext.Role
           .FirstOrDefaultAsync(r => r.RoleId == request.RoleId);

        if (dbRole == null)
        {
            throw new NotFoundException(nameof(Role), request.RoleId);
        }

        _adminDbContext.Role.Remove(dbRole);

        await _adminDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
