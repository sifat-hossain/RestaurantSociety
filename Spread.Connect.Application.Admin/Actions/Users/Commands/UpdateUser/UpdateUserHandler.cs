namespace Spread.Connect.Application.Admin.Actions.Users.Commands.UpdateUser;

/// <summary>
/// Represents logic for UpdateUserCommand
/// </summary>
public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IAdminDbContext _adminDbContext;

    public UpdateUserHandler(IAdminDbContext adminDbContext)
    {
        _adminDbContext = adminDbContext;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        SpreadUser existingUser = await _adminDbContext.SpreadUser
           // .Include(u => u.SpreadUserPermissions)
            .Include(u => u.SpreadUserRoles)
            .FirstOrDefaultAsync(u => u.SpreadUserId == request.UserId);

        if (existingUser == null)
        {
            throw new NotFoundException(nameof(SpreadUser), request.UserId);
        }

        List<Guid> roles = await _adminDbContext.Role
            .Where(r => request.Roles.Contains(r.RoleId))
            .Select(r => r.RoleId)
            .ToListAsync();

        if (!request.Roles.All(roles.Contains))
        {
            throw new NotFoundException(nameof(Role), request.Roles);
        }

        //List<Guid> permissions = await _adminDbContext.Permission
        //   .Where(p => request.Permissions.Select(up => up.PermissionId).Contains(p.PermissionId))
        //   .Select(up => up.PermissionId)
        //   .ToListAsync();

        //if (!request.Permissions.Select(up => up.PermissionId).All(permissions.Contains))
        //{
        //    throw new NotFoundException(nameof(Permission), request.Permissions);
        //}

        //List<Guid> tenantIds = await _adminDbContext.Tenant
        //    .Where(c => request.Permissions.Select(up => up.TenantId).Contains(c.TenantId))
        //    .Select(up => up.TenantId)
        //    .ToListAsync();

        //if (!request.Permissions.Select(up => up.TenantId).All(tenantIds.Contains))
        //{
        //    throw new NotFoundException(nameof(Tenant), request.Permissions);
        //}

        //existingUser.FirstName = request.FirstName;
        //existingUser.Surname = request.Surname;
        existingUser.Email = request.Email;


        IEnumerable<SpreadUserRole> rolesToRemove = existingUser.SpreadUserRoles.Where(ur => !request.Roles.Contains(ur.RoleId));
        IEnumerable<Guid> rolesToAdd = request.Roles.Where(r => !existingUser.SpreadUserRoles.Select(ur => ur.RoleId).Contains(r));

        _adminDbContext.SpreadUserRole.RemoveRange(rolesToRemove);

        existingUser.SpreadUserRoles.AddRange(rolesToAdd.Select(role => new SpreadUserRole
        {
            RoleId = role
        }));

        //IEnumerable<SpreadUserPermission> permissionsToRemove = existingUser.SpreadUserPermissions
        //    .Where(up => !request.Permissions.Any(r => r.TenantId == up.TenantId && r.PermissionId == up.PermissionId));

        //IEnumerable<UserPermissionCommandModel> permissionsToAdd = request.Permissions
        //    .Where(r => !existingUser.SpreadUserPermissions.Any(up => up.TenantId == r.TenantId && up.PermissionId == r.PermissionId));

        //_adminDbContext.SpreadUserPermission.RemoveRange(permissionsToRemove);

        //existingUser.SpreadUserPermissions.AddRange(permissionsToAdd.Select(permission => new SpreadUserPermission
        //{
        //    PermissionId = permission.PermissionId,
        //    TenantId = permission.TenantId
        //}));

        await _adminDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
