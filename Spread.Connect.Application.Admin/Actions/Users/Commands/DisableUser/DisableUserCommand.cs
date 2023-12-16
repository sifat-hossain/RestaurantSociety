namespace Spread.Connect.Application.Admin.Actions.Users.Commands.DisableUser;

/// <summary>
/// Represents model for disabling a user
/// </summary>
[SpreadRole(Constants.Roles.Admin)]
public class DisableUserCommand : IRequest
{
    /// <summary>
    /// User unique identifier
    /// </summary>
    public Guid UserId { get; set; }
}
