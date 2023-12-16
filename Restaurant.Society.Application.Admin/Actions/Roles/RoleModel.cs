using Restaurant.Society.Admin.Entities;

namespace Restaurant.Society.Application.Admin.Actions.Roles;

/// <summary>
/// Represents model for creating a role
/// </summary>
public class RoleModel
{
    #region Properties
    /// <summary>
    /// Role unique identifier
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// Role's name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Is role inactive?
    /// </summary>
    public bool Inactive { get; set; }
    #endregion

    public static Expression<Func<Role, RoleModel>> Projection
    {
        get
        {
            return role => new RoleModel
            {
                RoleId = role.RoleId,
                Name = role.Name,
                Inactive = role.Inactive
            };
        }
    }

    public static RoleModel Create(Role entity)
    {
        return Projection.Compile().Invoke(entity);
    }
}
