namespace Spread.Connect.Application.Admin.Actions.Users.Commands.CreateUser;

/// <summary>
/// Represents model for creating a user
/// </summary>
//[SpreadRole(Constants.Roles.Admin)]
public class CreateUserCommand : IRequest<UserModel>
{
    /// <summary>
    /// User first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// User surname
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// User username
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// User email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Tenant id
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// User password
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Confirm password
    /// </summary>
    public string ConfirmPassword { get; set; }

    /// <summary>
    /// User roles
    /// </summary>
    public List<Guid> Roles { get; set; } = new List<Guid>();

    /// <summary>
    /// User permissions
    /// </summary>
    public List<UserPermissionCommandModel> Permissions { get; set; } = new List<UserPermissionCommandModel>();
}
