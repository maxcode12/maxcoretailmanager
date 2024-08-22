using MaxCoRetailManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaxCoRetailManager.Persistence.Data;

public class MaxCoRetailDbContext : DbContext
{
    public MaxCoRetailDbContext(DbContextOptions<MaxCoRetailDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MaxCoRetailDbContext).Assembly);


        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleDetail> SaleDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Customer> Customers { get; set; }

}
