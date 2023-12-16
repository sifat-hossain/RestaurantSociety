using Restaurant.Society.Admin.Entities;

namespace Restaurant.Society.Application.Admin.Actions.Roles.Query.RoleDetails;

/// <summary>
/// Represents logic for RoleDetailsQuery
/// </summary>
public class RoleDetailsHandler : IRequestHandler<RoleDetailsQuery, RoleModel>
{
    private readonly IAdminDbContext _adminDbContext;

    public RoleDetailsHandler(IAdminDbContext adminDbContext)
    {
        _adminDbContext = adminDbContext;
    }

    public async Task<RoleModel> Handle(RoleDetailsQuery request, CancellationToken cancellationToken)
    {
        Role role = await _adminDbContext.Role
            .AsNoTracking()
            .SingleOrDefaultAsync(r => r.RoleId == request.RoleId);

        if (role == null)
        {
            throw new NotFoundException(nameof(Role), request.RoleId);
        }

        return RoleModel.Create(role);
    }
}
