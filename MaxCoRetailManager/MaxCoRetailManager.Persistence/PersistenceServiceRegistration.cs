using MaxCoRetailManager.Application.Contracts.Persistence;
using MaxCoRetailManager.Application.Contracts.Persistence.Categories;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Core.Entities;
using MaxCoRetailManager.Persistence.Data;
using MaxCoRetailManager.Persistence.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaxCoRetailManager.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection ConfigurePersistenceService
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MaxCoRetailDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SecondaryConnection")));

        services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
        services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<ISaleDetailRepository, SaleDetailRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();


        return services;
    }
}
