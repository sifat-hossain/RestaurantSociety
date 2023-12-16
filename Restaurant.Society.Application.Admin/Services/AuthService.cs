using Restaurant.Society.Application.Admin.Services.Responses;
using Restaurant.Society.Application.Admin.Services.Resquests;
using Restaurant.Society.Domain.Framework.Exceptions;
using System.Net;
using System.Text;
using System.Text.Json;
using ValidationException = Restaurant.Society.Domain.Framework.Exceptions.ValidationException;

namespace Restaurant.Society.Application.Admin.Services;

public class AuthService : IAuthService
{
    /// <summary>The HTTP client</summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>Logins the user asynchronous.</summary>
    /// <param name="request">The request.</param>
    /// <returns>The auth token and refresh token</returns>
    public Task<UserTokenResponse> LoginUserAsync(LoginUserRequest request)
    {
        string json = JsonSerializer.Serialize(request);

        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        var httpRequest = new HttpRequestMessage(HttpMethod.Post, "security/login")
        {
            Content = httpContent
        };

        return GetTokenAsync(httpRequest);
    }

    /// <summary>Refreshes the token asynchronous.</summary>
    /// <param name="request">The request.</param>
    /// <returns>The auth token and the refresh token</returns>
    public Task<UserTokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
    {
        string json = JsonSerializer.Serialize(request);

        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        var httpRequest = new HttpRequestMessage(HttpMethod.Post, "security/refresh-at")
        {
            Content = httpContent
        };

        return GetTokenAsync(httpRequest);
    }

    /// <summary>Gets the token asynchronous.</summary>
    /// <param name="httpRequest">The HTTP request.</param>
    /// <returns>The token</returns>
    /// <exception cref="UnauthorizedException">When the credentials are not correct</exception>
    /// <exception cref="ValidationException">Unknown error</exception>
    private async Task<UserTokenResponse> GetTokenAsync(HttpRequestMessage httpRequest)
    {
        HttpResponseMessage response = await _httpClient.SendAsync(httpRequest);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException();
        }
        else if (!response.IsSuccessStatusCode)
        {
            throw new ValidationException(await response.Content.ReadAsStringAsync());
        }

        string stringResult = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        UserTokenResponse result = JsonSerializer.Deserialize<UserTokenResponse>(stringResult, options);

        return result;
    }
}
