using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Society.Application.Admin.Actions.Emails.Commands;

namespace Restaurant.Society.Api.Admin.Controllers;
[EnableCors]
[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmailController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [EnableCors]
    [HttpPost("send-email")]
    public async Task<IActionResult> SendEmailAsync(EmailSenderCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
}
