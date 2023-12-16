using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spread.Connect.Application.Brotherhood.Actions.UserPaymentHistories;
using Spread.Connect.Application.Brotherhood.Actions.UserPaymentHistories.Commands;

namespace Spread.Connect.Api.Brotherhood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPaymentHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserPaymentHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public Task<List<UserPaymentHistoryModel>> UserPaymentHistoryAsync([FromQuery] int? skip,
        [FromQuery] int? take, [FromQuery] string? id)
        {
            return _mediator.Send(new UserPaymentHistoryQuery
            {
                UserId = id,
                Skip = skip,
                Take = take
            });
        }
    }
}
