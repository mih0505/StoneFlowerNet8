using ApplicationLayer.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TinyHelpers.Extensions;

namespace ApplicationLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

            var facades = assembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(FacadeBase)));
            facades.ForEach(facade => services.AddScoped(facade));

            services.AddValidatorsFromAssemblies(new[] { assembly })
                .AddTransient
                (
                    typeof(IPipelineBehavior<,>),
                    typeof(ValidationBehavior<,>)
                );

            return services;
        }
    }
}
