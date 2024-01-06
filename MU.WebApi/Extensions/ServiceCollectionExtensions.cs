using MU.Application.Interfaces;
using MU.Application.Services;
using MU.Domain.Entities;

namespace MU.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceProperty, ServiceProperty>();
            return services;
        }
    }
}
