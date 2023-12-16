using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Spread.Connect.Domain.Framework.Interfaces
{
    public interface IUserDbContext
    {
        //DbSet<User> User { get; set; }
        //DbSet<Permission> Permission { get; set; }
        //DbSet<Role> Role { get; set; }
        //DbSet<UserRole> UserRole { get; set; }
        //DbSet<UserPermission> UserPermission { get; set; }
        //DbSet<Customer> Customer { get; set; }
        //DbSet<VehicleCheckQuestion> VehicleCheckQuestion { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
