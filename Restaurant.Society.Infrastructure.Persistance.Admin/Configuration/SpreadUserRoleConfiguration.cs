using Restaurant.Society.Admin.Entities;

namespace Restaurant.Society.Infrastructure.Persistance.Admin.Configuration
{
    public class SpreadUserRoleConfiguration : IEntityTypeConfiguration<SpreadUserRole>
    {
        public void Configure(EntityTypeBuilder<SpreadUserRole> builder)
        {
            builder.HasKey(b => b.SpreadUserRoleId);

            builder.Property(b => b.SpreadUserRoleId)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(b => b.SpreadUser)
                .WithMany(u => u.SpreadUserRoles)
                .HasForeignKey(b => b.SpreadUserId);

            builder.HasIndex(b => b.SpreadUserId);

            builder.HasOne(b => b.Role)
                .WithMany(r => r.SpreadUserRoles)
                .HasForeignKey(b => b.RoleId);

            builder.HasIndex(b => b.RoleId);
        }
    }
}
