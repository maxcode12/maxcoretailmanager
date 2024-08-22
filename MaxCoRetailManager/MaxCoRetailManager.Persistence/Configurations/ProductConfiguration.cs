using MaxCoRetailManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxCoRetailManager.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        //confgure the primary key
        builder.HasKey(p => p.Id);

        //configure the properties

        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(p => p.Description)
            .HasMaxLength(512);
        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)");
        builder.Property(p => p.ImageUrl)
            .HasMaxLength(512);

        //configure relationships
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.User)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.Location)
            .WithMany(l => l.Products)
            .HasForeignKey(p => p.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Inventories)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict);


    }
}
