using MaxCoRetailManager.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MaxCoRetailManager.Identity.IdentityContext;

public class MaxCoRetailIdentityDbContext : IdentityDbContext<User>
{
    public MaxCoRetailIdentityDbContext(DbContextOptions<MaxCoRetailIdentityDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(MaxCoRetailIdentityDbContext).Assembly);
        base.OnModelCreating(builder);
        //configuring the assembly

    }


    public DbSet<User> Users { get; set; }

}
