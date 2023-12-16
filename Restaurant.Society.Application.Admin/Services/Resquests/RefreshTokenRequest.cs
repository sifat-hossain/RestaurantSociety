namespace Restaurant.Society.Application.Admin.Services.Resquests;

/// <summary>
/// Represents model for refreshing token
/// </summary>
public class RefreshTokenRequest
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
