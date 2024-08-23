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

        // Relationships between entities

        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.Product)
            .WithMany(p => p.Inventories)
            .HasForeignKey(i => i.ProductId);

        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.Location)
            .WithMany(l => l.Inventories)
            .HasForeignKey(i => i.LocationId);

        //modelBuilder.Entity<Inventory>()
        //    .HasOne(i => i.User)
        //    .WithMany(u => u.Inventories)
        //    .HasForeignKey(i => i.UserId)
        //    //.HasPrincipalKey(u => u.Id)
        //    .HasConstraintName("FK_Inventory_User")
        //    .OnDelete(DeleteBehavior.NoAction)

        ;

        //modelBuilder.Entity<Product>()
        //    .HasOne(p => p.User)
        //    .WithMany(u => u.Products)
        //    .HasForeignKey(p => p.UserId)
        //     .HasPrincipalKey(u => u.Id)
        //    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Location)
            .WithMany(l => l.Products)
            .HasForeignKey(p => p.LocationId);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Sales)
            .WithOne(s => s.Product)
            .HasForeignKey(s => s.ProductId);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.SaleDetails)
            .WithOne(sd => sd.Product)
            .HasForeignKey(sd => sd.ProductId);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Inventories)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId);

        //modelBuilder.Entity<Sale>()
        //    .HasOne(s => s.User)
        //    .WithMany(u => u.Sales)
        //    .HasForeignKey(s => s.UserId)
        //    //.HasPrincipalKey(s => s.Id)
        //    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Sale>()
            .HasMany(s => s.SaleDetails)
            .WithOne(sd => sd.Sale)
            .HasForeignKey(sd => sd.SaleId);

        modelBuilder.Entity<SaleDetail>()
            .HasOne(sd => sd.Product)
            .WithMany(p => p.SaleDetails)
            .HasForeignKey(sd => sd.ProductId);

        modelBuilder.Entity<SaleDetail>()
            .HasOne(sd => sd.Sale)
            .WithMany(s => s.SaleDetails)
            .HasForeignKey(sd => sd.SaleId);

        //modelBuilder.Entity<Category>()
        //    .HasOne(c => c.User)
        //    .WithMany(u => u.Categories)
        //    .HasForeignKey(c => c.UserId)
        //    .HasPrincipalKey(c => c.Id)
        //    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Category>()
            .HasOne(c => c.ParentCategory)
            .WithMany(c => c.Categories)
            .HasForeignKey(c => c.ParentCategoryId);

        //modelBuilder.Entity<Location>()
        //    .HasOne(l => l.User)
        //    .WithMany(u => u.Locations)
        //    .HasForeignKey(l => l.UserId)
        //    //.HasPrincipalKey(l => l.Id)
        //    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Location>()
            .HasMany(l => l.Products)
            .WithOne(p => p.Location)
            .HasForeignKey(p => p.LocationId);

        //modelBuilder.Entity<Customer>()
        //    .HasOne(c => c.User)
        //    .WithMany(u => u.Customers)
        //    .HasForeignKey(c => c.CreatedBy)
        //    //.HasPrincipalKey(c => c.Id)
        //    .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<User>()
        //    .HasMany(u => u.Categories)
        //    .WithOne(c => c.User)
        //    .HasForeignKey(c => c.UserId)
        //    .HasPrincipalKey(c => c.Id)
        //    .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<Payment>()
        //    .HasOne(p => p.User)
        //    .WithMany(u => u.Payments)
        //    .HasForeignKey(p => p.UserId)
        //    //.HasPrincipalKey(p => p.Id)
        //    .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Customer)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.CustomerId);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Sale)
            .WithMany(s => s.Payments)
            .HasForeignKey(p => p.SaleId);

        //modelBuilder.Entity<Payment>()
        //    .HasOne(p => p.SaleDetail)
        //    .WithMany(sd => sd.Payments)
        //    .HasForeignKey(p => p.SaleDetailId);


    }

    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleDetail> SaleDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Payment> Payments { get; set; }

}
