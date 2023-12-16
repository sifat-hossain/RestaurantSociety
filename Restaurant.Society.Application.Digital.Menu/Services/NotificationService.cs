using Restaurant.Society.Domain.Framework.Contracts.Email;
using Restaurant.Society.Domain.Framework.Services;
using Restaurant.Society.Identity.Extensions;

namespace Restaurant.Society.Application.Digital.Menu.Services;

public sealed class NotificationService : BaseHttpService, INotification
{
    /// <summary>The HTTP client</summary>
    private readonly HttpClient _httpClient;

    /// <summary>The indentity context.</summary>
    private readonly IIdentityContext _identityContext;

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
}
