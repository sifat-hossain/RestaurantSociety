using Microsoft.Extensions.Configuration;
using Restaurant.Society.Application.Notification.Interfaces;
using Restaurant.Society.Domain.Framework.Contracts.Email;
using System.Net;
using System.Net.Mail;

namespace Restaurant.Society.Infrastructure.Services.Notification.Services;

public class EmailService : IEmailService
{
    /// <summary> The logger </summary>
    //private readonly ILogger<EmailService> _logger;

    /// <summary> The configuration service </summary>
    private readonly IConfiguration _configuration;

    /// <summary>Initializes a new instance of the <see cref="EmailService"/> class.</summary>
    /// <param name="logger">The logger.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="hostingEnvironment">The hosting environment.</param>

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<bool> SendEmailAsync(EmailHelper email)
    {
        if (!Convert.ToBoolean(_configuration["ShouldSendEmails"]))
        {
            return false;
        }

        string from, host, user, password;

        if (_configuration["DefaultEmailSender"] == "brevo")
        {
            host = _configuration["BrevoConfiguration:SmtpServer"];
        }

        from = _configuration["OutlookEmailConfiguration:SmtpUsername"];
        user = _configuration["OutlookEmailConfiguration:SmtpUsername"];
        host = _configuration["OutlookEmailConfiguration:SmtpServer"];
        password = _configuration["OutlookEmailConfiguration:SmtpPassword"];

        int smtpPort = Convert.ToInt16(_configuration["OutlookEmailConfiguration:SmtpPort"]);

        MailMessage mailMessage = new MailMessage();

        mailMessage.From = new MailAddress(from);
        mailMessage.To.Add(new MailAddress(email.Email));

        if (email.CcEmail != null)
        {
            List<string> ccAddress = new List<string>();
            foreach (string ccadd in ccAddress)
            {
                if (ccadd.Length > 0)
                {
                    mailMessage.CC.Add(ccadd);
                }
            }
        }

        if (email.BccEmail != null)
        {
            List<string> bccAddress = new List<string>();
            foreach (string bccadd in bccAddress)
            {
                if (bccadd.Length > 0)
                {
                    mailMessage.Bcc.Add(bccadd);
                }
            }
        }

        //Set additional options
        mailMessage.Priority = MailPriority.High;
        //Text/HTML
        mailMessage.IsBodyHtml = true;

        mailMessage.Subject = email.Subject;
        mailMessage.Body = email.Content;

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = host;
        smtpClient.Port = smtpPort;

        //************ Adding Auth************//
        NetworkCredential NetworkCred = new NetworkCredential(user, password);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = NetworkCred;
        smtpClient.EnableSsl = true;
        try
        {
            // Send the email
            await smtpClient.SendMailAsync(mailMessage);

        }
        catch (Exception ex)
        {

            return false;
        }
        return true;
    }
}