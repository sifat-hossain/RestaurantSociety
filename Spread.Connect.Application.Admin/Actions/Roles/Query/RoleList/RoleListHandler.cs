namespace Spread.Connect.Application.Admin.Actions.Roles.Query.RoleList;

/// <summary>
/// Represents logic for RoleListQuery
/// </summary>
public class RoleListHandler : IRequestHandler<RoleListQuery, List<RoleModel>>
{
    private readonly IAdminDbContext _adminDbContext;

    public RoleListHandler(IAdminDbContext adminDbContext)
    {
        _adminDbContext = adminDbContext;
    }

    public async Task<List<RoleModel>> Handle(RoleListQuery request, CancellationToken cancellationToken)
    {
        List<Role> roles = await _adminDbContext.Role
            .AsNoTracking()
            .ToListAsync();

        return roles.Select(r => RoleModel.Create(r)).ToList();
    }
}
