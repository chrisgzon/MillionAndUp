using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MU.Domain.Entities.Properties;
using MU.Domain.Primitives;
using MU.Infrastructure.Contexts;
using MU.Infrastructure.Repositories;

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
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<MUContext>());

            services.AddScoped<IRepositoryProperty, PropertyRepository>();
            return services;
        }
    }
}
