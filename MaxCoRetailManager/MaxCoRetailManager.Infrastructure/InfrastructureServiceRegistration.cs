using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaxCoRetailManager.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection ConfigureInfraService
        (this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }
}
