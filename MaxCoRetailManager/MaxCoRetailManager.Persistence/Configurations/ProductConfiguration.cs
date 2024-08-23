using MaxCoRetailManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxCoRetailManager.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Configure the primary key
        builder.HasKey(p => p.Id);

        // Configure the properties
        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(512)
            .IsRequired(false);

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired(false);

        builder.Property(p => p.ImageUrl)
            .HasMaxLength(512)
            .IsRequired(false);

        builder.Property(p => p.Sku)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.DeliveryTimeSpan)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.IsAvailable)
            .IsRequired(false);

        builder.Property(p => p.IsOnSale)
            .IsRequired(false);

        builder.Property(p => p.IsSellOnPOS)
            .IsRequired(false);

        builder.Property(p => p.IsSellOnline)
            .IsRequired(false);

        builder.Property(p => p.CategoryId)
            .IsRequired(false);

        builder.Property(p => p.LocationId)
            .IsRequired(false);

        //builder.Property(p => p.UserId)
        //    .HasMaxLength(450)
        //    .IsRequired(false);

    }
}
