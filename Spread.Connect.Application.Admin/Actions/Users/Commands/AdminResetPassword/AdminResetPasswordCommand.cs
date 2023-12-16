namespace Spread.Connect.Application.Admin.Actions.Users.Commands.AdminResetPassword;

/// <summary>
/// Represents model for resetting a user's password
/// </summary>
[SpreadRole(Constants.Roles.Admin)]
public class AdminResetPasswordCommand : IRequest
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
    /// User's confirm password
    /// </summary>
    [SensitiveData]
    public string ConfirmPassword { get; set; }
}
