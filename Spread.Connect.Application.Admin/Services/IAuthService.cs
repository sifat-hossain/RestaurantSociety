using Spread.Connect.Application.Admin.Services.Responses;
using Spread.Connect.Application.Admin.Services.Resquests;

namespace Spread.Connect.Application.Admin.Services;

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
