using Microsoft.Extensions.DependencyInjection;

namespace MaxCoRetailManager.Identity;

public static class AssemblyIdentityRegisterService
{
    public static IServiceCollection AddIdentityRegisterService(this IServiceCollection services)
    {
        //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        //services.AddDbContext<FlatpurseAppDbContext>(options =>
        //       options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        //       b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)), ServiceLifetime.Scoped);

        //services.AddIdentity<User, IdentityRole>(
        //    op => op.SignIn.RequireConfirmedAccount = true)
        //                .AddEntityFrameworkStores<FlatpurseAppDbContext>().AddDefaultTokenProviders();

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

        //services.AddIdentityCore<User, IdentityRole>(options =>
        //{
        //    options.Password.RequireDigit = true;
        //    options.Password.RequireLowercase = true;
        //    options.Password.RequireUppercase = true;
        //    options.Password.RequireNonAlphanumeric = true;
        //    options.Password.RequiredLength = 8;
        //    options.User.RequireUniqueEmail = true;
        //})
        //    .AddEntityFrameworkStores<MaxCoRetailManagerDbContext>()
        //    .AddDefaultTokenProviders();

        return services;
    }
}
