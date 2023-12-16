﻿using Restaurant.Society.Domain.Framework.Contracts.Email;

namespace Restaurant.Society.Application.Admin.Services;

public interface INotificationService
{
    /// <summary>Send email for Reset the user password asynchronous.</summary>
    /// <param name="request">The request.</param>
   //   Task SendResetPasswordEmailAsync(SendResetPasswordEmailRequest request);
    Task SendEmail(EmailHelper emailHelper);
}
