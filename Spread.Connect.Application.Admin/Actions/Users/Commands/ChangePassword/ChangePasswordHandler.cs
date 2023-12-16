using Microsoft.Extensions.Logging;
using static BCrypt.Net.BCrypt;

namespace Spread.Connect.Application.Admin.Actions.Users.Commands.ChangePassword;

/// <summary>
/// Represents logic for ChangePasswordCommand
/// </summary>
public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand>
{
    /// <summary>The logger</summary>
    private readonly ILogger<ChangePasswordHandler> _logger;

    /// <summary>The admin datbase context</summary>
    private readonly IAdminDbContext _adminDbContext;


    /// <param name="logger">The logger service</param>
    /// <param name="adminDbContext"> The admin DbContext </param>
    public ChangePasswordHandler(IAdminDbContext adminDbContext, ILogger<ChangePasswordHandler> logger)
    {
        _adminDbContext = adminDbContext;
        _logger = logger;
    }

    /// <summary>
    /// Handles the logic for changing user password
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogTrace("Get user information by id {0}", request.UserId);

            var user = await _adminDbContext.SpreadUser
                .SingleOrDefaultAsync(u => u.SpreadUserId == request.UserId,
                                      cancellationToken: cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(SpreadUser), request.UserId);
            }
            user.Password = HashPassword(request.ConfirmNewPassword);

            if (user.RequiresPasswordReset)
            {
                user.RequiresPasswordReset = false;
            }

            await _adminDbContext.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            throw;
        }

        return Unit.Value;
    }
}
