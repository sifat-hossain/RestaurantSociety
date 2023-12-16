using Restaurant.Society.Application.Admin.Services.Responses;
using Restaurant.Society.Application.Admin.Services.Resquests;

namespace Restaurant.Society.Application.Admin.Services;

public interface IAuthService
{
    /// <summary>Logins the user asynchronous.</summary>
    /// <param name="request">The request.</param>
    /// <returns>The auth token and refresh token</returns>
    Task<UserTokenResponse> LoginUserAsync(LoginUserRequest request);

    /// <summary>Refreshes the token asynchronous.</summary>
    /// <param name="request">The request.</param>
    /// <returns>The auth token and refresh token</returns>
    Task<UserTokenResponse> RefreshTokenAsync(RefreshTokenRequest request);
}
