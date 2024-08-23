using MaxCoRetailManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxCoRetailManager.Persistence.Configurations;



public class SalesConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.SaleDate)
            .IsRequired()
            .HasColumnType("datetime2");

        builder.Property(s => s.Total)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        //builder.Property(s => s.UserId)
        //    .HasMaxLength(450)
        //    .IsRequired(false);



        builder.Property(s => s.ProductId)
            .HasColumnType("int")
            .IsRequired(false);

    }
}
