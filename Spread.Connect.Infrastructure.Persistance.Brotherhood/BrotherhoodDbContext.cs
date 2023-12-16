using Microsoft.EntityFrameworkCore;
using Spread.Connect.Application.Brotherhood;
using Spread.Connect.Domain.Brotherhood.Dtos;
using Spread.Connect.Domain.Brotherhood.Entities.Payments;

namespace Spread.Connect.Infrastructure.Persistance.Brotherhood;

public class BrotherhoodDbContext : DbContext, IBrotherhoodDbContext
{
    public BrotherhoodDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<PaymentRequest> PaymentRequest { get; set; }
    public DbSet<PaymentHistory> PaymentHistories { get; set; }
    public DbSet<ApplicationSetting> ApplicationSettings { get; set; }

    protected override void ConfigureConventions(
       ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<decimal>()
            .HavePrecision(9, 2);

        configurationBuilder
            .Properties<decimal?>()
            .HavePrecision(9, 2);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BrotherhoodDbContext).Assembly);
        modelBuilder.Ignore<ApplicationSetting>();
    }

}
