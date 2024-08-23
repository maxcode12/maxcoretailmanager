using MaxCoRetailManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaxCoRetailManager.Persistence;

public class SeedCategory : IEntityTypeConfiguration<Category>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category { Id = 1, Name = "Electronics", Description = "Electronic gadgets" },
            new Category { Id = 2, Name = "Clothing", Description = "Clothing items" },
            new Category { Id = 3, Name = "Furniture", Description = "Furniture items" },
            new Category { Id = 4, Name = "Grocery", Description = "Grocery items" }
            );
    }
}
