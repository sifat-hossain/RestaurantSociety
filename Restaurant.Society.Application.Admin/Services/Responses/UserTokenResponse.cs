namespace Restaurant.Society.Application.Admin.Services.Responses;

/// <summary>
/// Represents model for creating a user token
/// </summary>
public record UserTokenResponse
{
    /// <summary>
    /// User access token
    /// </summary>
    public string AccessToken { get; init; }

    /// <summary>
    /// User refresh token
    /// </summary>
    public string RefreshToken { get; init; }
}

