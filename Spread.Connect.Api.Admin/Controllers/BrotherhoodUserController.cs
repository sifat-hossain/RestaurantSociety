using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Spread.Connect.Application.Admin.Actions;
using Spread.Connect.Application.Admin.Actions.BrotherhoodUsers;
using Spread.Connect.Application.Admin.Actions.BrotherhoodUsers.Commands;
using Spread.Connect.Application.Admin.Actions.BrotherhoodUsers.Query;
using System.Net.Mime;

namespace Spread.Connect.Api.Admin.Controllers;

[EnableCors]
[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
[Produces(MediaTypeNames.Application.Json)]
public class BrotherhoodUserController : ControllerBase
{
    private readonly IMediator _mediator;
    public BrotherhoodUserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [EnableCors]
    [HttpPost]
    public Task<ActionResponse<SpreadUserModel>> CreateBrotherhoodAsync(CreateSpreadUserCommand command)
    {
        return _mediator.Send(command);
    }
    [EnableCors]
    [HttpGet]
    public Task<List<SpreadUserModel>> Pull()
    {
        return _mediator.Send(new SpreadUserQuery());
    }

}
