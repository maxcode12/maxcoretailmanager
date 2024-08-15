using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace MaxCoRetailManager.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        // Register all Automapper profiles at once
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //MediatR
        services.AddMediatR(op =>
        {
            op.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            //op.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());

        });






        return services;
    }

}
