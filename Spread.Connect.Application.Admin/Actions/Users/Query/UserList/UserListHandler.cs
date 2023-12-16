namespace Spread.Connect.Application.Admin.Actions.Users.Query.UserList;

/// <summary>
/// Represents logic for UserListQuery
/// </summary>
public class UserListHandler : IRequestHandler<UserListQuery, List<UserModel>>
{
    private readonly IAdminDbContext _adminDbContext;

    public UserListHandler(IAdminDbContext adminDbContext)
    {
        _adminDbContext = adminDbContext;
    }

    public async Task<List<UserModel>> Handle(UserListQuery request, CancellationToken cancellationToken)
    {
        int skip = request.Skip ?? 0;

        IQueryable<SpreadUser> userQuery = _adminDbContext.SpreadUser
            .Include(u => u.SpreadUserRoles)
                .ThenInclude(ur => ur.Role)
           // .Include(u => u.SpreadUserPermissions)
              //  .ThenInclude(up => up.Permission)
            .AsNoTracking()
            .Skip(skip);

        if (request.Take.HasValue)
        {
            userQuery = userQuery.Take(request.Take.Value);
        }

        List<SpreadUser> users = await userQuery.ToListAsync();

        return users.Select(u => UserModel.Create(u)).ToList();
    }
}
