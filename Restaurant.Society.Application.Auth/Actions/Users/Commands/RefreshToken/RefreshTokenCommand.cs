namespace Restaurant.Society.Application.Auth.Actions.Users.Commands.RefreshToken;

/// <summary>
/// Represents model for refreshing token
/// </summary>
public class RefreshTokenCommand : IRequest<UserTokenModel>
{
    /// <summary>
    /// User refresh token
    /// </summary>
    public string RefreshToken { get; set; }

    /// <summary>
    /// Users username
    /// </summary>
    public string Username { get; set; }
}
