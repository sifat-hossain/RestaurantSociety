using Spread.Connect.Domain.Admin.Entities;

namespace Spread.Connect.Application.Auth;

/// <summary>
/// The interface to abstract the auth database
/// </summary>
public interface IAuthDbContext
{
    DbSet<SpreadUser> SpreadUser { get; set; }
    DbSet<SpreadUserRole> SpreadUserRole { get; set; }

    /// <summary>
    /// Saves the changes
    /// </summary>
    /// <returns>The number of state entries written to the database</returns>
    int SaveChanges();

    /// <summary>
    /// Saves the changes async
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>The number of state entries written to the database</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
