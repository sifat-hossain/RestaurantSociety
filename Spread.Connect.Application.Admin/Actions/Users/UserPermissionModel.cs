namespace Spread.Connect.Application.Admin.Actions.Users;

/// <summary>
/// Represents model for creating a user permission
/// </summary>
public class UserPermissionModel
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// User unique identifier
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Permission unique identifier
    /// </summary>
    public Guid PermissionId { get; set; }

    /// <summary>
    /// User permission's name
    /// </summary>
    public string Name { get; set; }
}
