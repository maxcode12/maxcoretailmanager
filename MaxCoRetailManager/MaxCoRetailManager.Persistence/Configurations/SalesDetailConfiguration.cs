using MaxCoRetailManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxCoRetailManager.Persistence.Configurations;

public class SalesDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
{
    public void Configure(EntityTypeBuilder<SaleDetail> builder)
    {
        //configure the primary key
        builder.HasKey(sd => sd.Id);

        //configure relationship the foreign key
        builder.HasOne(sd => sd.Sale)
            .WithMany(s => s.SaleDetails)
            .HasForeignKey(sd => sd.SaleId);

        builder.HasOne(sd => sd.Product)
            .WithMany(p => p.SaleDetails)
            .HasForeignKey(sd => sd.ProductId);



        builder.HasOne(sd => sd.Location)
            .WithMany(l => l.SaleDetails)
            .HasForeignKey(sd => sd.LocationId);

        //configure the properties
        builder.Property(sd => sd.Quantity)
            .HasColumnType("int")
            .IsRequired();

    }
}
