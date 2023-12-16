namespace Spread.Connect.Application.Admin.Actions.Users;

/// <summary>
/// Represents model for creating a user permission
/// </summary>
public class UserPermissionCommandModel
{
    /// <summary>
    /// Tenant unique identifier
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Permission unique identifier
    /// </summary>
    public Guid PermissionId { get; set; }
}
