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


        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.HasMany(e => e.Inventories)
            .WithOne(e => e.Product)
            .HasForeignKey(e => e.ProductId);

        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.ProductId);
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity).HasColumnType("int");
            entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity).HasColumnType("int");
            entity.Property(e => e.CashierId).HasMaxLength(450);
            entity.Property(e => e.SaleDate).HasColumnType("datetime");
            entity.HasMany(e => e.SaleDetails)
            .WithOne(e => e.Sale)
            .HasForeignKey(e => e.SaleId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<SaleDetail>(SaleDetail =>
        {
            SaleDetail.HasKey(e => new { e.SaleId, e.ProductId });
            SaleDetail.Property(e => e.Quantity).HasColumnType("int");
            SaleDetail.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 2)");
            SaleDetail.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(200);
        });

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
