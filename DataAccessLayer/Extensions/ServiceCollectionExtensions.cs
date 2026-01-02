using ApplicationLayer.Interfaces;
using Domain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccessLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessLayer(
        this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("StoneFlowerConnection");

            services.AddDbContext<StoneFlowersDbContext>
            (
                options => options.UseNpgsql(connectionString, b => b.MigrationsAssembly("DataAccessLayer"))
            );



            services.AddScoped<IStoneFlowersDbContext>
            (
                provider => provider.GetService<StoneFlowersDbContext>()
            );

            return services;
        }
    }
}
