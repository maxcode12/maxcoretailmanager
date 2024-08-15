using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxCoRetailManager.Identity.DataSeed;

public class RoleSeed : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "8b693986-0d12-487f-9fde-e0e983e2f51c",
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Id = "c619043f-2923-4180-95fc-1104ed3ddc3e",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
             new IdentityRole
             {
                 Id = "c619453f-2973-4180-78fc-1b84ed3dkc3o",
                 Name = "Manager",
                 NormalizedName = "MANAGER"
             },
              new IdentityRole
              {
                  Id = "d6s9043f-3924-4589-05fq-1i94ed3ddc3f",
                  Name = "Cashier",
                  NormalizedName = "CASHIER"
              }
            );
    }
}
