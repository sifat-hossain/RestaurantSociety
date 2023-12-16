namespace Spread.Connect.Application.Admin.Actions.Users.Commands.ChangePassword;

/// <summary>
/// Represents model for changing a user's password
/// </summary>
public class ChangePasswordCommand : IRequest
{
    /// <summary>
    /// User unique identifier
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// User's new password
    /// </summary>
    [SensitiveData]
    public string NewPassword { get; set; }

    /// <summary>
    /// User's confirmed new password
    /// </summary>
    [SensitiveData]
    public string ConfirmNewPassword { get; set; }
}
