using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spread.Connect.Domain.Brotherhood.Entities.Payments;

namespace Spread.Connect.Infrastructure.Persistance.Brotherhood.Configuration;

public class PaymentConfiguration : IEntityTypeConfiguration<PaymentHistory>
{
    public void Configure(EntityTypeBuilder<PaymentHistory> builder)
    {
        builder.ToTable(nameof(PaymentHistory));

        builder.HasKey(b => b.PaymentHistoryId);

        builder.Property(b => b.PaymentHistoryId)
            .HasDefaultValueSql("NEWID()");

        builder.Property(b => b.TrxId)
            .IsRequired();

        builder.HasIndex(b => b.TrxId)
            .IsUnique();

        builder.Property(b => b.Phone)
            .IsRequired();
    }
}