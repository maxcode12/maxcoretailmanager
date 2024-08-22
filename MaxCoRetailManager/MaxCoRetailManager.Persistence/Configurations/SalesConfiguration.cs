using MaxCoRetailManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxCoRetailManager.Persistence.Configurations;

public class SalesConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        //configure table
        builder.ToTable("Sales");

        //configure keys
        builder.HasKey(s => s.Id);

        //configure relationships
        builder.HasOne(s => s.Location)
            .WithMany(l => l.Sales)
            .HasForeignKey(s => s.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Cashier)
            .WithMany(u => u.Sales)
            .HasForeignKey(s => s.CashierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Product)
            .WithMany(p => p.Sales)
            .HasForeignKey(s => s.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Inventories)
            .WithOne(i => i.Sale)
            .HasForeignKey(i => i.SaleId)
            .OnDelete(DeleteBehavior.Restrict);

        //properties
        builder.Property(s => s.SubTotal)
            .HasColumnType("decimal(18,2)");

        builder.Property(s => s.Tax)
            .HasColumnType("decimal(18,2)");

        builder.Property(s => s.Total)
            .HasColumnType("decimal(18,2)");

        builder.Property(s => s.Quantity)
            .HasColumnType("int");

        builder.Property(s => s.CashierId)
            .HasColumnType("nvarchar(450)");

        builder.Property(s => s.ProductId)
                        .HasColumnType("int");

        builder.Property(s => s.LocationId)
                       .HasColumnType("int");



    }
}
