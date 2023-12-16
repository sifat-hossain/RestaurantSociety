using Restaurant.Society.Admin.Entities;
using Restaurant.Society.Application.Admin;
using Restaurant.Society.Application.Auth;

namespace Restaurant.Society.Infrastructure.Persistance.Admin
{
    public class AdminDbContext : DbContext, IAdminDbContext, IAuthDbContext
    {
        public AdminDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SpreadUser> SpreadUser { get; set; }
        public DbSet<SpreadUserRole> SpreadUserRole { get; set; }
        public DbSet<Role> Role { get; set; }
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdminDbContext).Assembly);
        }
    }
}
