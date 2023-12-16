using Restaurant.Society.Domain.Framework.Contracts.Email;

namespace Restaurant.Society.Application.Notification.Interfaces;

public interface IEmailService
{
    Task<bool> SendEmailAsync(EmailHelper email);
}
