using MaxCoRetailManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxCoRetailManager.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        //configure table
        builder.ToTable("Categories");

        //configure primary keys
        builder.HasKey(c => c.Id);

        //configure properties

        builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(250);
        builder.Property(c => c.CreatedAt).HasDefaultValueSql("getdate()");
        builder.Property(c => c.UpdatedAt).HasDefaultValueSql("getdate()");

        //configure relationships
        builder.HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

    }

}
