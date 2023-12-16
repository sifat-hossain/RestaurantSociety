using MediatR;
using Microsoft.EntityFrameworkCore;
using Spread.Connect.Domain.Brotherhood.Entities.Payments;

namespace Spread.Connect.Application.Brotherhood.Actions.UserPaymentHistories.Commands;

public class UserPaymentHistoryQueryHandler : IRequestHandler<UserPaymentHistoryQuery, List<UserPaymentHistoryModel>>
{
    private readonly IBrotherhoodDbContext _brotherhoodDbContext;

    public UserPaymentHistoryQueryHandler(IBrotherhoodDbContext brotherhoodDbContext)
    {
        _brotherhoodDbContext = brotherhoodDbContext;
    }

    public async Task<List<UserPaymentHistoryModel>> Handle(UserPaymentHistoryQuery request, CancellationToken cancellationToken)
    {
        int skip = request.Skip ?? 0;

        //IQueryable<PaymentHistory> userQuery = _brotherhoodDbContext.PaymentHistories
        //    //.Include(u => u.SpreadUserRoles)
        //    // .ThenInclude(ur => ur.Role)
        //    // .Include(u => u.SpreadUserPermissions)
        //    //  .ThenInclude(up => up.Permission)
        //    .AsNoTracking()
        //    .Skip(skip);

        IQueryable<PaymentHistory> userQuery = _brotherhoodDbContext.PaymentHistories
            .Where(w => w.UserId == request.UserId)
            .AsNoTracking()
            .Skip(skip);


        if (request.Take.HasValue)
        {
            userQuery = userQuery.Take(request.Take.Value);
        }

        List<PaymentHistory> userPayment = await userQuery.ToListAsync();

        return userPayment.Select(u => UserPaymentHistoryModel.Create(u)).ToList();
    }
}
