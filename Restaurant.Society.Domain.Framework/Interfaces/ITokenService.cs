using Restaurant.Society.Domain.Digital.Menu;

namespace Restaurant.Society.Domain.Framework.Interfaces;

public interface ITokenService
{
    /// <summary>
    /// Generates JWT token for user
    /// </summary>
    /// <param name="user">User entity</param>
    /// <returns>New JWT token</returns>
    string GenerateToken(ISpreadTokanable user);

    /// <summary>
    /// Generates refresh token
    /// </summary>
    /// <returns>New Refresh token</returns>
    string GenerateRefreshToken();

    /// <summary>
    /// Generates a new JWT token for a merlin user
    /// </summary>
    /// <param name="user">Merlin user</param>
    /// <returns>New JWT token</returns>
    string GenerateMerlinToken(ITokenable user);
    string GenerateTempPassword();
}
