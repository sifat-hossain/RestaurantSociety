using Restaurant.Society.Admin.Entities;
using Restaurant.Society.Domain.Digital.Menu;
using Restaurant.Society.Domain.Framework.Exceptions;
using Restaurant.Society.Domain.Framework.Interfaces;
using Restaurant.Society.Domain.Framework.Settings;
using static BCrypt.Net.BCrypt;

namespace Restaurant.Society.Application.Auth.Actions.Users.Commands.LoginUser;

/// <summary>
/// Represents logic for LoginUserCommand
/// </summary>
public class LoginUserHandler : IRequestHandler<LoginUserCommand, UserTokenModel>
{
    private readonly IAuthDbContext _userDbContext;
    private readonly AuthSettings _authSettings;
    private readonly IDateTime _dateTime;
    private readonly ITokenService _tokenService;

    public LoginUserHandler(IAuthDbContext userDbContext,
        IOptions<AuthSettings> options,
        IDateTime dateTime,
        ITokenService tokenService)
    {
        _userDbContext = userDbContext;
        _authSettings = options.Value;
        _dateTime = dateTime;
        _tokenService = tokenService;
    }

    public async Task<UserTokenModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            SpreadUser? user = await _userDbContext.SpreadUser
                //.Include(u => u.Tenant)
                .Include(u => u.SpreadUserRoles)
                    .ThenInclude(u => u.Role)
                //.Include(u => u.SpreadUserPermissions)
                // .ThenInclude(u => u.Permission)
                .SingleOrDefaultAsync(u => u.UserName == request.Username);

            VerifyUserExists(request, user);

            VerifyEligibility(user);

            if (!Verify(request.Password, user.Password))
            {
                user.LoginAttempts += 1;
                user.IsSuspended = user.LoginAttempts == _authSettings.LoginAttempts;
                if (user.IsSuspended)
                {
                    user.SuspendedUntil = _dateTime.UtcNow.AddMinutes(_authSettings.SuspendedTime);
                }

                await _userDbContext.SaveChangesAsync(cancellationToken);

                throw new AuthenticationException("Invalid username or password");
            }

            if (user.ExpirationDate < _dateTime.UtcNow || user.RefreshToken is null)
            {
                user.RefreshToken = _tokenService.GenerateRefreshToken();
                user.ExpirationDate = _dateTime.UtcNow.AddMonths(_authSettings.LifetimeMonths);
                await _userDbContext.SaveChangesAsync(cancellationToken);
            }

            return new UserTokenModel
            {
                RefreshToken = user.RefreshToken,
                RequiresPasswordReset = user.RequiresPasswordReset,
                AccessToken = _tokenService.GenerateToken(user)
            };
        }
        catch (Exception e)
        {
            var x = e.Message + e.InnerException?.Message;
            throw;
        }
    }

    /// <summary>
    /// verify eligiblity
    /// </summary>
    /// <param name="user"></param>
    /// <exception cref="AuthenticationException"></exception>
    private void VerifyEligibility(SpreadUser user)
    {
        if (user.IsSuspended && user.SuspendedUntil > _dateTime.UtcNow)
        {
            throw new AuthenticationException("Could not authorize user");
        }
        else if (user.IsSuspended)
        {
            user.LoginAttempts = 0;
            user.IsSuspended = false;
            user.SuspendedUntil = null;
        }
    }

    /// <summary>
    /// verify existance
    /// </summary>
    /// <param name="request"></param>
    /// <param name="entity"></param>
    /// <exception cref="NotFoundException"></exception>
    private void VerifyUserExists(LoginUserCommand request, SpreadUser entity)
    {
        if (entity == null)
        {
            throw new NotFoundException(nameof(SpreadUser), request.Username);
        }
    }
}
