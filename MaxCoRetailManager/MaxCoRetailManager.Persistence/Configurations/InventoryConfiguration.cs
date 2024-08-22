using MaxCoRetailManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxCoRetailManager.Persistence.Configurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        //confgure the primary key
        builder.HasKey(i => i.Id);

        //configure relationships
        builder.HasOne(i => i.Product)
            .WithMany(p => p.Inventories)
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Location)
            .WithMany(l => l.Inventories)
            .HasForeignKey(i => i.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.User)
            .WithMany(u => u.Inventories)
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        //configure the properties
        builder.Property(i => i.PurchasePrice)
            .HasColumnType("decimal(18,2)");
    }
}
