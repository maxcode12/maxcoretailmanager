
using MaxCoRetailManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxCoRetailManager.Persistence.Configurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventories");

        // Primary key
        builder.HasKey(i => i.Id);

        // Set properties
        builder.Property(i => i.PurchasePrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(i => i.Quantity)
            .IsRequired();

        //builder.Property(i => i.UserId)
        //    .HasMaxLength(450);

        builder.Property(i => i.PurchaseDate)
            .HasColumnType("datetime2");
    }
}
