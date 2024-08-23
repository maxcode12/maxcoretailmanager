
using MaxCoRetailManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxCoRetailManager.Persistence.Configurations;

public class SalesDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
{
    public void Configure(EntityTypeBuilder<SaleDetail> builder)
    {
        builder.ToTable("SalesDetails");

        builder.HasKey(sd => sd.Id);

        builder.Property(sd => sd.Quantity)
            .IsRequired();

        builder.Property(sd => sd.PurchasePrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

    }
}

