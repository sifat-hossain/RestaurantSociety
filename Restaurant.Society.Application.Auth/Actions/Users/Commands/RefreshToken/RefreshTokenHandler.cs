
using Restaurant.Society.Admin.Entities;
using Restaurant.Society.Domain.Framework.Exceptions;
using Restaurant.Society.Domain.Framework.Interfaces;

namespace Restaurant.Society.Application.Auth.Actions.Users.Commands.RefreshToken;

/// <summary>
/// Represents logic for RefreshTokenCommand
/// </summary>
public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, UserTokenModel>
{
    private readonly IAuthDbContext _userDbContext;
    private readonly ITokenService _tokenService;

    public RefreshTokenHandler(IAuthDbContext userDbContext,
        ITokenService tokenService)
    {
        _userDbContext = userDbContext;
        _tokenService = tokenService;
    }

    public async Task<UserTokenModel> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        SpreadUser user = await _userDbContext.SpreadUser
            // .Include(u => u.Tenant)
            .Include(u => u.SpreadUserRoles)
                .ThenInclude(u => u.Role)
            //.Include(u => u.SpreadUserPermissions)
            //  .ThenInclude(u => u.Permission)
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.UserName == request.Username);

        if (user == null)
        {
            throw new NotFoundException(nameof(SpreadUser), request.Username);
        }

        if (user.ExpirationDate < DateTime.UtcNow
                || user.RefreshToken != request.RefreshToken)
        {
            throw new AuthenticationException("Refresh token invalid or expired");
        }

        return new UserTokenModel
        {
            RefreshToken = user.RefreshToken,
            AccessToken = _tokenService.GenerateToken(user)
        };
    }

    private static void VerifyClientExists(RefreshTokenCommand request, SpreadUser entity)
    {
        if (entity == null)
        {
            throw new NotFoundException(nameof(SpreadUser), request.RefreshToken);
        }
    }
}
