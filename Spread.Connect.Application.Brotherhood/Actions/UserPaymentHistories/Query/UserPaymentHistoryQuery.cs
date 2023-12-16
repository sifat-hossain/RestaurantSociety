using MediatR;

namespace Spread.Connect.Application.Brotherhood.Actions.UserPaymentHistories.Commands;

public class UserPaymentHistoryQuery : IRequest<List<UserPaymentHistoryModel>>
{
    public string UserId { get; set; }
    public int? Skip { get; set; }
    public int? Take { get; set; }
}
