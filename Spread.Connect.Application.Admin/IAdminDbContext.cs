namespace Spread.Connect.Application.Admin;

/// <summary>
/// The interface to abstract the admin database
/// </summary>
public interface IAdminDbContext
{
    DbSet<ApplicationSetting> ApplicationSettings { get; set; }
    DbSet<Role> Role { get; set; }
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
