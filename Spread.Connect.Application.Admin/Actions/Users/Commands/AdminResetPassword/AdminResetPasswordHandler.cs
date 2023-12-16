using static BCrypt.Net.BCrypt;

namespace Spread.Connect.Application.Admin.Actions.Users.Commands.AdminResetPassword;

/// <summary>
/// Represents logic for AdminResetPasswordCommand
/// </summary>
public class AdminResetPasswordHandler : IRequestHandler<AdminResetPasswordCommand>
{
    private readonly IAdminDbContext _adminDbContext;

    public AdminResetPasswordHandler(IAdminDbContext adminDbContext)
    {
        _adminDbContext = adminDbContext;
    }

    public async Task<Unit> Handle(AdminResetPasswordCommand request, CancellationToken cancellationToken)
    {
        SpreadUser? user = await _adminDbContext.SpreadUser
           .SingleOrDefaultAsync(u => u.SpreadUserId == request.UserId, cancellationToken: cancellationToken);

        if (user == null)
        {
           // throw new NotFoundException(nameof(MerlinUser), request.UserId);
        }

        user.Password = HashPassword(request.ConfirmPassword);

        await _adminDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
