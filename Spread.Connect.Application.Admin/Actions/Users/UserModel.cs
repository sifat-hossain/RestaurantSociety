namespace Spread.Connect.Application.Admin.Actions.Users;

/// <summary>
/// Represents model for creating a user
/// </summary>
public class UserModel
{
    #region Properties
    /// <summary>
    /// User unique identifier
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// User's first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// User's surname
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// User's username
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// User's email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Tenant unique identifier
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// User's roles
    /// </summary>
    public List<string> Roles { get; set; } = new List<string>();

    /// <summary>
    /// User's permission models
    /// </summary>
    public List<UserPermissionModel> UserPermissionModels { get; set; } = new List<UserPermissionModel>();
    #endregion

    public static Expression<Func<SpreadUser, UserModel>> Projection
    {
        get
        {
            return user => new UserModel
            {
                UserId = user.SpreadUserId,
                //FirstName = user.FirstName,
                //Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,
               // TenantId = user.TenantId,
                Roles = user.SpreadUserRoles.Where(ur => ur.Role != null).Select(ur => ur.Role.Name).ToList(),
                //UserPermissionModels = user.SpreadUserPermissions.Select(up => new UserPermissionModel
                //{
                //    Id = up.SpreadUserPermissionId,
                //    Name = up.Permission != null
                //     ? up.Permission.Name
                //     : string.Empty,
                //    PermissionId = up.PermissionId,
                //    UserId = up.SpreadUserId
                //}).ToList()
            };
        }
    }

    public static UserModel Create(SpreadUser entity)
    {
        return Projection.Compile().Invoke(entity);
    }
}
