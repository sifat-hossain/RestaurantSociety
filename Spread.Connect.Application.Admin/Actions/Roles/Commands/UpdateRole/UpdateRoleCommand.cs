namespace Spread.Connect.Application.Admin.Actions.Roles.Commands.UpdateRole;

/// <summary>
/// Represents model for updating a role
/// </summary>
[SpreadRole(Constants.Roles.Admin)]
public class UpdateRoleCommand : IRequest
{
    /// <summary>
    /// Role unique identifier
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// Role name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Role inactive flag
    /// </summary>
    public bool Inactive { get; set; }
}
