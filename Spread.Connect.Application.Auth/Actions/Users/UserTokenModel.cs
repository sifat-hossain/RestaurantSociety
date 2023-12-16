namespace Spread.Connect.Application.Auth.Actions.Users;

/// <summary>
/// Represents model for creating a user token
/// </summary>
public class UserTokenModel
{
    /// <summary>
    /// User access token
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// User refresh token
    /// </summary>
    public string RefreshToken { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the password needs to be changed after login.
    /// </summary>
    /// <value>
    ///   <c>true</c> if password needs to be changed; otherwise, <c>false</c>.
    /// </value>
    public bool RequiresPasswordReset { get; set; }
}
