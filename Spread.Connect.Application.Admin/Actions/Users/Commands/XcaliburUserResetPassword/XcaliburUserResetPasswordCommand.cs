namespace Spread.Connect.Application.Admin.Actions.Users.Commands.SpreadUserResetPassword;

/// <summary>
/// Represents model for resetting Spread user password
/// </summary>
public class SpreadUserResetPasswordCommand : IRequest
{
    /// <summary>
    /// User's email
    /// </summary>
    public string Email { get; set; }
}
