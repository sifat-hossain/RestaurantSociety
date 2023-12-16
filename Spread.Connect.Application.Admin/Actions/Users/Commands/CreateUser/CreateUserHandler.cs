using Microsoft.Extensions.Configuration;
using static BCrypt.Net.BCrypt;

namespace Spread.Connect.Application.Admin.Actions.Users.Commands.CreateUser;

/// <summary>
/// Represents logic for CreateUserCommand
/// </summary>
public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserModel>
{
    private readonly IAdminDbContext _adminDbContext;
    private readonly IIdentityContext _identityContext;
    private readonly IConfiguration _configuration;

    public CreateUserHandler(IAdminDbContext adminDbContext,
        IIdentityContext identityContext, IConfiguration configuration)
    {
        _adminDbContext = adminDbContext;
        _identityContext = identityContext;
        _configuration = configuration;
    }

    public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            //Tenant tenant = await _adminDbContext.Tenant.FindAsync(request.TenantId);

            //if (tenant == null)
            //{
            //    throw new ConflictException(nameof(Tenant), request.TenantId);
            //}

            SpreadUser existingUser = await _adminDbContext.SpreadUser
                .FirstOrDefaultAsync(u => u.UserName == request.UserName);

            if (existingUser != null)
            {
                throw new ConflictException(nameof(SpreadUser), request.UserName);
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
            //    .Where(p => request.Permissions.Select(up => up.PermissionId).Contains(p.PermissionId))
            //    .Select(up => up.PermissionId)
            //    .ToListAsync();

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

            var user = new SpreadUser
            {
                //FirstName = request.FirstName,
                //Surname = request.Surname,
                UserName = request.UserName,
                Email = request.Email,
                //TenantId = tenant.TenantId,
                Password = HashPassword(request.Password),
               // LogLevel = Convert.ToInt32(_configuration["UserDefaultLogValue"])
            };
            user.SpreadUserRoles.AddRange(roles.Select(role => new SpreadUserRole
            {
                RoleId = role
            }));
            //user.SpreadUserPermissions.AddRange(request.Permissions.Select(permission => new SpreadUserPermission
            //{
            //    PermissionId = permission.PermissionId,
            //    TenantId = permission.TenantId
            //}));

            _adminDbContext.SpreadUser.Add(user);

            await _adminDbContext.SaveChangesAsync(cancellationToken);

            return UserModel.Create(user);
        }
        catch (Exception e)
        {
            var x = e.Message + e.InnerException?.Message;
            throw;
        }
    }
}
