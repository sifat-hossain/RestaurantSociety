﻿using MediatR;
using Restaurant.Society.Application.Notification.Interfaces;
using Restaurant.Society.Domain.Framework.Contracts.Email;

namespace Restaurant.Society.Application.Notification.Actions.Email.Command.TestMail;

public class EmailSenderHandler : IRequestHandler<EmailSenederCommand>
{

    /// <summary>The email service.</summary>
    private readonly IEmailService _emailService;

    public EmailSenderHandler(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task<Unit> Handle(EmailSenederCommand request, CancellationToken cancellationToken)
    {

        EmailHelper mail = new EmailHelper()
        {
            Email = request.Email,
            Subject = request.Subject,
            Content = request.Content,
            CcEmail = request.CcEmail,
            BccEmail = request.BccEmail,
            //ContentType = 0, // html
            //SaveToSentItems = false
        };
        await _emailService.SendEmailAsync(mail);

        return Unit.Value;

    }
}
