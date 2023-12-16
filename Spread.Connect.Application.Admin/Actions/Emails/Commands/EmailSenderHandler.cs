using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
namespace Spread.Connect.Application.Admin.Actions.Emails.Commands;

public class EmailSenderHandler : IRequestHandler<EmailSenderCommand>
{
    public EmailSenderHandler()
    {

    }
    public async Task<Unit> Handle(EmailSenderCommand command, CancellationToken cancellationToken)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress("", command.From));
        message.To.Add(new MailboxAddress("", command.To));
        message.Subject = command.Subject;
        message.Body = new TextPart("plain")
        {
            Text = command.Body
        };
        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            client.Authenticate(command.From, "ilookfairi3x");
            var res = client.Send(message);
            client.Disconnect(true);
        }
        return Unit.Value;
    }
}
