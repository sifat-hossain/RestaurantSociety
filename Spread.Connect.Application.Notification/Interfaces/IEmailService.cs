using Spread.Connect.Domain.Framework.Contracts.Email;

namespace Spread.Connect.Application.Notification.Interfaces;

public interface IEmailService
{
    Task<bool> SendEmailAsync(EmailHelper email);
}
