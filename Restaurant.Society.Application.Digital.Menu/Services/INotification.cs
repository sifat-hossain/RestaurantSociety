using Restaurant.Society.Domain.Framework.Contracts.Email;

namespace Restaurant.Society.Application.Digital.Menu.Services;

public interface INotification
{
    Task SendEmail(EmailHelper emailHelper);
}
