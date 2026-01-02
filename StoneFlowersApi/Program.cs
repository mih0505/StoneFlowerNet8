using AccessLayer;
using AccessLayer.Extensions;
using ApplicationLayer.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataAccessLayer(builder.Configuration);

// Configure Identity (register RoleManager/UserManager etc.)
builder.Services.AddIdentity<Domain.Common.User, Domain.Common.Role>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<AccessLayer.StoneFlowersDbContext>();

builder.Services.AddControllers();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorDev", policy =>
    {
        policy
            .WithOrigins("http://localhost:5033", "https://localhost:5033") // адрес вашего Blazor-приложения
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add application services (CQRS facades/handlers, validators etc.)
builder.Services.AddApplication();

// AutoMapper profiles from Application layer
// Register AutoMapper profiles from loaded assemblies
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply migrations and initialize DB
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var context = services.GetRequiredService<StoneFlowersDbContext>();
        context.Database.Migrate();
        await DbInitializer.InitializeAsync(services);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating or initializing the database.");
        throw;
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Подключаем CORS ДО MapControllers и ДО UseAuthorization
app.UseCors("AllowBlazorDev");

app.UseAuthorization();
app.MapControllers();

app.Run();
