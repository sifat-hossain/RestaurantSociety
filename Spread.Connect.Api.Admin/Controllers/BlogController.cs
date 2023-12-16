using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Spread.Connect.Api.Admin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{

    private readonly IMediator _mediator;

    public BlogController(IMediator mediator)
    {
        _mediator = mediator;
    }


}
