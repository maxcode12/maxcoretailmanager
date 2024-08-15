using MaxCoRetailManager.Persistence.Data;
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
            options.UseSqlServer(configuration.GetConnectionString("ProductConnection")));



        return services;
    }
}
