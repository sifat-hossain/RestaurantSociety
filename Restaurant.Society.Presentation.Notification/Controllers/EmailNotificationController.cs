using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Society.Application.Notification.Actions.Email.Command.TestMail;
using System.Net.Mime;

namespace Restaurant.Society.Api.Notification.Controllers;

//[ApiKeyFilter]
[Authorize]
[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class EmailNotificationController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmailNotificationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[AllowAnonymous]
    //[HttpPost("send-reset-password-email")]
    //public Task<Unit> SendResetPasswordEmail(SendResetPasswordEmailCommand command)
    //{
    //    return _mediator.Send(command);
    //}

    [AllowAnonymous]
    [HttpPost("email-sender")]
    public Task<Unit> EamilSender(EmailSenederCommand command)
    {
        return _mediator.Send(command);
    }
}
