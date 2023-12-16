using Restaurant.Society.Admin.Entities;

namespace Restaurant.Society.Infrastructure.Persistance.Admin.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(b => b.RoleId);

        builder.Property(b => b.RoleId)
            .HasDefaultValueSql("NEWID()");

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Name);

        builder.HasIndex(b => b.Name)
            .IsUnique();

        builder.Property(b => b.Inactive)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasData(new[]
        {
            new Role { RoleId = Guid.Parse("fc67814d-11c7-486a-90d0-0c79c18de656"), Name = "SuperAdmin", Inactive=false },
            new Role { RoleId = Guid.Parse("fc67814d-11c7-486a-90d0-0c79c18de655"), Name = "Admin", Inactive=false },
            new Role { RoleId = Guid.Parse("0da3649e-e5ec-4c5b-a9c0-ec3b19f86e0c"), Name = "User", Inactive=false },
            new Role { RoleId = Guid.Parse("0de3eb68-12aa-4f09-99d7-58ef9ca090c2"), Name = "Finance", Inactive=false }
        });
    }
}
