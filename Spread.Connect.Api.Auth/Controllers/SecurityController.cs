﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Spread.Connect.Application.Auth.Actions.Users;
using Spread.Connect.Application.Auth.Actions.Users.Commands.LoginUser;
using Spread.Connect.Application.Auth.Actions.Users.Commands.RefreshToken;
using System.Net.Mime;

namespace Spread.Connect.Api.Auth.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SecurityController : Controller
{
    private readonly IMediator _mediator;

    public SecurityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [EnableCors]
    [HttpPost("login")]
    public Task<UserTokenModel> LoginUserAsync(LoginUserCommand command)
    {
        return _mediator.Send(command);
    }

    [EnableCors]
    [AllowAnonymous]
    [HttpPost("refresh-at")]
    public Task<UserTokenModel> RefreshTokenAsync(RefreshTokenCommand command)
    {
        return _mediator.Send(command);
    }
}

