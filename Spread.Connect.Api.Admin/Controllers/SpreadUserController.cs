using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Spread.Connect.Application.Admin.Actions.Users;
using Spread.Connect.Application.Admin.Actions.Users.Commands.AdminResetPassword;
using Spread.Connect.Application.Admin.Actions.Users.Commands.ChangePassword;
using Spread.Connect.Application.Admin.Actions.Users.Commands.CreateUser;
using Spread.Connect.Application.Admin.Actions.Users.Commands.DisableUser;
using Spread.Connect.Application.Admin.Actions.Users.Commands.SpreadUserResetPassword;
using Spread.Connect.Application.Admin.Actions.Users.Commands.UpdateUser;
using Spread.Connect.Application.Admin.Actions.Users.Query.UserList;
using System.Net.Mime;

namespace Spread.Connect.Api.Admin.Controllers;

//[Authorize]
//[ApiController]
[EnableCors]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SpreadUserController : ControllerBase
{
    private readonly IMediator _mediator;

    public SpreadUserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [EnableCors]
    [HttpPut()]
    public async Task<IActionResult> UpdateUserAsync(UpdateUserCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
    [EnableCors]
    [HttpPost()]
    public Task<UserModel> CreateUserAsync(CreateUserCommand command)
    {
        return _mediator.Send(command);
    }
    [EnableCors]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangeUserPasswordAsync(ChangePasswordCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
    [EnableCors]
    [HttpPost("disable")]
    public async Task<IActionResult> DisableUserAsync(DisableUserCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
    [EnableCors]
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetUserPasswordsync(AdminResetPasswordCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
    [EnableCors]
    [HttpGet()]
    public Task<List<UserModel>> UserListAsync([FromQuery] int? skip,
        [FromQuery] int? take)
    {
        return _mediator.Send(new UserListQuery
        {
            Skip = skip,
            Take = take
        });
    }

    //[HttpPost("sync-driver")]
    //public Task<DriverModel> SyncDriverAsync(SyncDriverCommand command)
    //{
    //    return _mediator.Send(command);
    //}

    [AllowAnonymous]
    [HttpPost("Spread-user-reset-password")]
    public async Task<IActionResult> SpreadUserResetPasswordSync(
        SpreadUserResetPasswordCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
}
