using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Society.Application.Admin.Actions.Roles;
using Restaurant.Society.Application.Admin.Actions.Roles.Commands.CreateRole;
using Restaurant.Society.Application.Admin.Actions.Roles.Commands.DeleteRole;
using Restaurant.Society.Application.Admin.Actions.Roles.Commands.UpdateRole;
using Restaurant.Society.Application.Admin.Actions.Roles.Query.RoleDetails;
using Restaurant.Society.Application.Admin.Actions.Roles.Query.RoleList;
using System.Net.Mime;

namespace Restaurant.Society.Api.Admin.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public Task<RoleModel> CreateRoleAsync(CreateRoleCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleAsync(Guid id)
        {
            await _mediator.Send(new DeleteRoleCommand
            {
                RoleId = id
            });

            return NoContent();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateRoleAsync(UpdateRoleCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet()]
        public Task<List<RoleModel>> GetRolesAsync()
        {
            return _mediator.Send(new RoleListQuery());
        }

        [HttpGet("{id}")]
        public Task<RoleModel> GetRoleAsync(Guid id)
        {
            return _mediator.Send(new RoleDetailsQuery
            {
                RoleId = id
            });
        }
    }
}
