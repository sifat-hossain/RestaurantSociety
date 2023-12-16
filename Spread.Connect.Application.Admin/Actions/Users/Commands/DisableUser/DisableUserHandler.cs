namespace Spread.Connect.Application.Admin.Actions.Users.Commands.DisableUser;

/// <summary>
/// Represents logic for DisableUserCommand
/// </summary>
public class DisableUserHandler : IRequestHandler<DisableUserCommand>
{
    private readonly IAdminDbContext _adminDbContext;

    public DisableUserHandler(IAdminDbContext adminDbContext)
    {
        _adminDbContext = adminDbContext;
    }

    public async Task<Unit> Handle(DisableUserCommand request, CancellationToken cancellationToken)
    {
        SpreadUser user = await _adminDbContext.SpreadUser
           .SingleOrDefaultAsync(u => u.SpreadUserId == request.UserId);

        if (user == null)
        {
            throw new NotFoundException(nameof(SpreadUser), request.UserId);
        }

        user.IsDeleted = true;

        await _adminDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
