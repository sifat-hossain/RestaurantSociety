using Restaurant.Society.Domain.Framework.Contracts.Email;
using Restaurant.Society.Domain.Framework.Services;
using Restaurant.Society.Identity.Extensions;

namespace Restaurant.Society.Application.Admin.Services;

public sealed class NotificationService : BaseHttpService, INotificationService
{
    /// <summary>The HTTP client</summary>
   // private readonly HttpClient _httpClient;

    /// <summary>The indentity context.</summary>
  //  private readonly IIdentityContext _identityContext;

    /// <summary>The auth settings.</summary>
   // private AuthSettings _authSettings;


    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    /// <param name="authSettings">The auth settings.</param>
    /// <param name="identityContext">The identity context.</param>
    public NotificationService(HttpClient httpClient,
         IIdentityContext identityContext) : base(httpClient, identityContext)
    {
    }

    public Task SendEmail(EmailHelper emailHelper) => SendAsync(emailHelper, $"EmailNotification/email-sender", HttpMethod.Post);

    //public async Task SendEmail(EmailHelper emailHelper)
    //{
    //    string authHeader = _identityContext.AuthorizationHeader;
    //    string authScheme = _identityContext.AuthorizationScheme;

    //    string json = JsonSerializer.Serialize(emailHelper);

    //    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

    //    var request = new HttpRequestMessage(HttpMethod.Post, "EmailNotification/email-sender");

    //    if (!string.IsNullOrEmpty(authHeader) && !string.IsNullOrEmpty(authScheme))
    //    {
    //        request.Headers.Authorization =
    //           new AuthenticationHeaderValue(authScheme, authHeader);
    //    }

    //    request.Content = httpContent;

    //    HttpResponseMessage response = await _httpClient.SendAsync(request);

    //    if (response.StatusCode == HttpStatusCode.Unauthorized)
    //        throw new UnauthorizedException();

    //    //else if (!response.IsSuccessStatusCode)
    //    //    throw new System.ComponentModel.DataAnnotations.ValidationException(await response.Content.ReadAsStringAsync());
    //}


    //public async Task SendResetPasswordEmailAsync(SendResetPasswordEmailRequest request)
    //{
    //    string json = JsonSerializer.Serialize(request);

    //    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

    //    var httpRequest = new HttpRequestMessage(HttpMethod.Post, "emailnotification/send-reset-password-email")
    //    {
    //        Content = httpContent
    //    };

    //    httpRequest.Headers.Add("Authorization", $"Bearer {_identityContext.AuthorizationHeader}");
    //    httpContent.Headers.Add("ApiKey", _authSettings.ApiKey);

    //    await _httpClient.SendAsync(httpRequest);
    //}
}
