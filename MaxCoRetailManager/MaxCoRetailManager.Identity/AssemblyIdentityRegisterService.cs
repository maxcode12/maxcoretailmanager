using MaxCoRetailManager.Identity.IdentityContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaxCoRetailManager.Identity;

public static class AssemblyIdentityRegisterService
{
    public static IServiceCollection AddIdentityRegisterService(this IServiceCollection services
        , IConfiguration configuration)
    {
        //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddDbContext<MaxCoRetailIdentityDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(AssemblyIdentityRegisterService).Assembly.FullName)),
               ServiceLifetime.Scoped);

        //services.AddIdentity<User, IdentityRole>(
        //    op => op.SignIn.RequireConfirmedAccount = true)
        //                .AddEntityFrameworkStores<MaxCoRetailIdentityDbContext>()
        //                .AddDefaultTokenProviders();



        //services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IAuthRepository, AuthRepository>();
        //services.AddScoped<UserManager<User>, UserManager<User>>();

        //services.AddAuthentication(
        //    options =>
        //    {
        //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        //    }).AddJwtBearer(options =>
        //    {
        //        options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,
        //            ClockSkew = TimeSpan.Zero,
        //            ValidIssuer = configuration["JwtSettings:Issuer"],
        //            ValidAudience = configuration["JwtSettings:Audience"],
        //            IssuerSigningKey = new SymmetricSecurityKey
        //            (Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
        //        };
        //    });



        return services;
    }
}
