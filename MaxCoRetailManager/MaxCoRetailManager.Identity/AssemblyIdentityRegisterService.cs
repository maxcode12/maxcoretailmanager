using MaxCoRetailManager.Application.Settings;
using MaxCoRetailManager.Core.Entities;
using MaxCoRetailManager.Core.IRepos.Identity;
using MaxCoRetailManager.Identity.IdentityContext;
using MaxCoRetailManager.Identity.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.Design;
using System.Text;

namespace MaxCoRetailManager.Identity;

public static class AssemblyIdentityRegisterService
{
    public static IServiceCollection AddIdentityRegisterService(this IServiceCollection services
        , IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddDbContext<MaxCoRetailIdentityDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)), ServiceLifetime.Scoped);

        services.AddIdentity<User, IdentityRole>(
            op => op.SignIn.RequireConfirmedAccount = true)
                        .AddEntityFrameworkStores<MaxCoRetailIdentityDbContext>().AddDefaultTokenProviders();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<UserManager<User>, UserManager<User>>();

        services.AddAuthentication(
            options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });

        services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 8;
            options.User.RequireUniqueEmail = true;
        })
            .AddEntityFrameworkStores<MaxCoRetailIdentityDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}
