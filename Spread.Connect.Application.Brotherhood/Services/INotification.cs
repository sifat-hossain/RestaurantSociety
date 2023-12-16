using Spread.Connect.Domain.Framework.Contracts.Email;

namespace Spread.Connect.Application.Brotherhood.Services;

public interface INotification
{
    Task SendEmail(EmailHelper emailHelper);
}
