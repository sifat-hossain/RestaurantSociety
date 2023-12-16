namespace Spread.Connect.Infrastructure.Persistance.Admin.Configuration;

public class SpreadUserConfiguration : IEntityTypeConfiguration<SpreadUser>
{
    public void Configure(EntityTypeBuilder<SpreadUser> builder)
    {
        builder.ToTable(nameof(SpreadUser));

        builder.HasKey(b => b.SpreadUserId);

        builder.Property(b => b.SpreadUserId)
            .HasDefaultValueSql("NEWID()");

        builder.Property(b => b.UserName)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Name);

        builder.HasIndex(b => b.UserName)
            .IsUnique();

        builder.Property(b => b.Name)
               .IsRequired()
               .HasMaxLength(Constants.FieldSize.Name);

        builder.Property(b => b.FatherName)
             .IsRequired()
             .HasMaxLength(Constants.FieldSize.Name);

        builder.Property(b => b.MotherName)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Name);

        builder.Property(b => b.Email)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Email);

        builder.HasIndex(b => b.Email)
             .IsUnique();

        builder.Property(b => b.Phone)
           .IsRequired()
           .HasMaxLength(Constants.FieldSize.AccountNumber);

        builder.Property(b => b.AlternatePhone)
             .HasMaxLength(Constants.FieldSize.AccountNumber);

        builder.Property(b => b.NID)
            .IsRequired();

        builder.HasIndex(b => b.NID)
            .IsUnique();

        builder.Property(b => b.BloodGroup);

        builder.Property(b => b.Religion)
            .IsRequired();

        builder.Property(b => b.ProfessionalStatus)
            .IsRequired();

        builder.Property(b => b.MaritalStatus)
            .IsRequired();

        builder.Property(b => b.DateOfBirth)
            .IsRequired();

        builder.Property(b => b.PresentAddress)
            .IsRequired();

        builder.Property(b => b.PermanentAddress)
            .IsRequired();

        builder.Property(b => b.School)
            .IsRequired();

        builder.Property(b => b.College)
            .IsRequired();

        builder.Property(b => b.University);


        builder.Property(b => b.Password)
            .IsRequired()
            .HasMaxLength(Constants.FieldSize.Password);

        builder.Property(b => b.RefreshToken)
            .HasMaxLength(Constants.FieldSize.Token);

        builder.Property(b => b.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(b => b.LoginAttempts)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(b => b.IsSuspended)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(b => b.IsPasswordReset)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(b => b.ImagePath)
            .HasMaxLength(Constants.FieldSize.FilePath);

        //builder.Property(b => b.FirstName)
        //    .IsRequired()
        //    .HasMaxLength(Constants.FieldSize.Name);

        //builder.Property(b => b.Surname)
        //    .IsRequired()
        //    .HasMaxLength(Constants.FieldSize.Name);

        //builder.HasOne(b => b.Tenant)
        //    .WithMany(t => t.SpreadUsers)
        //    .HasForeignKey(b => b.TenantId)
        //    .OnDelete(DeleteBehavior.NoAction);

        //builder.Property(b => b.LogLevel)
        //    .HasDefaultValue(4);
    }
}
