using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MU.Application.Services.ImageService;
using MU.Domain.Entities.Properties;
using MU.Domain.Interfaces.Repositories;
using MU.Domain.Primitives;
using MU.Infrastructure.Contexts;
using MU.Infrastructure.Persistence.Repositories;
using MU.Infrastructure.Repositories;
using MU.Infrastructure.Services.ImageStorage;

namespace MU.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MUContext>(options => options.UseSqlServer(configuration.GetConnectionString("MU_SQL_DefaultConection")));
            services.AddScoped<IUnitOfWork>(sp =>
                sp.GetRequiredService<MUContext>());

            services.AddScoped<IRepositoryProperty, PropertyRepository>();
            services.AddScoped<IRepositoryOwner, OwnerRepository>();
            services.AddScoped<IRepositoryPropertyImage, PropertyImageRepository>();
            services.AddScoped<IImageService, ImageService>();
            return services;
        }
    }
}
