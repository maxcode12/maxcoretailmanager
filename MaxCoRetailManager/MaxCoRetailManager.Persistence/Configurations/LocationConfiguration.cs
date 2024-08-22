using MaxCoRetailManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxCoRetailManager.Persistence.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        //configure table
        builder.ToTable("Locations");

        //configure keys
        builder.HasKey(l => l.Id);

        //configure relationships
        builder.HasMany(l => l.Products)
            .WithOne(p => p.Location)
            .HasForeignKey(p => p.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(l => l.Inventories)
            .WithOne(i => i.Location)
            .HasForeignKey(i => i.LocationId)
            .OnDelete(DeleteBehavior.Restrict);



        builder.HasMany(l => l.Sales)
            .WithOne(s => s.Location)
            .HasForeignKey(s => s.LocationId)
            .OnDelete(DeleteBehavior.Restrict);




    }
}
