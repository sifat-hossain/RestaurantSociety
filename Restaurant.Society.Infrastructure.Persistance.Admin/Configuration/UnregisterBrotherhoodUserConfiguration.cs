using Restaurant.Society.Admin.Entities;

namespace Restaurant.Society.Infrastructure.Persistance.Admin.Configuration;

public class UnregisterBrotherhoodUserConfiguration : IEntityTypeConfiguration<UnregisterBrotherhoodUser>
{
    public void Configure(EntityTypeBuilder<UnregisterBrotherhoodUser> builder)
    {
        builder.ToTable(nameof(UnregisterBrotherhoodUser));

        builder.HasKey(x => x.UserId);

        builder.Property(x => x.UserId)
            .HasDefaultValueSql("NEWID()");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Name);

        builder.Property(x => x.MobileNo)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.AccountNumber);

        builder.Property(x => x.IsRegistered)
           .IsRequired()
           .HasDefaultValue(false);
    }
}
