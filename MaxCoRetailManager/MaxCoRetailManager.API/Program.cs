using MaxCoRetailManager.Application;
using MaxCoRetailManager.Identity;
using MaxCoRetailManager.Persistence;

var builder = WebApplication.CreateBuilder(args);





// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();


app.MapControllers();


app.Run();
