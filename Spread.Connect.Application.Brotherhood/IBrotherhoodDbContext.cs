using Microsoft.EntityFrameworkCore;
using Spread.Connect.Domain.Brotherhood.Dtos;
using Spread.Connect.Domain.Brotherhood.Entities.Payments;

namespace Spread.Connect.Application.Brotherhood;

public interface IBrotherhoodDbContext
{
    DbSet<PaymentHistory> PaymentHistories { get; set; }
    DbSet<ApplicationSetting> ApplicationSettings { get; set; }
    DbSet<PaymentRequest> PaymentRequest { get; set; }
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

