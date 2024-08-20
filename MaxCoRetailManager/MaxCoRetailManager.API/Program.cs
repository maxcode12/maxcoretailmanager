using MaxCoRetailManager.Application;
using MaxCoRetailManager.Identity;
using MaxCoRetailManager.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);





// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "MaxCo Retail Manager APIs",
        Version = "v1",

        Contact = new OpenApiContact
        {
            Name = "MaxCo Retail Manager",
            Email = "hissoundemdia@gmail.com",
            Url = new Uri("https://www.maxcoretailmanager.com"),
        },
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Bearer{token}"

    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddIdentityRegisterService(builder.Configuration);
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceService(builder.Configuration);


// Register ILogger
builder.Services.AddLogging();

//Register the CORS service


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder
            .WithOrigins("http://localhost:4200/")
            .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();


app.Run();
