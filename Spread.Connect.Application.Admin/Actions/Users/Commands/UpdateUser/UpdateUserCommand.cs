namespace Spread.Connect.Application.Admin.Actions.Users.Commands.UpdateUser;

/// <summary>
/// Represents model for updating a user
/// </summary>
[SpreadRole(Constants.Roles.Admin)]
public class UpdateUserCommand : IRequest
{
    /// <summary>
    /// User unique identifier
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// User first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// User surname
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// User email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// User roles
    /// </summary>
    public List<Guid> Roles { get; set; } = new List<Guid>();

    /// <summary>
    /// User permissions
    /// </summary>
    public List<UserPermissionCommandModel> Permissions { get; set; } = new List<UserPermissionCommandModel>();
}
