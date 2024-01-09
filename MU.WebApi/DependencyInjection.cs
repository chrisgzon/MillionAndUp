using Microsoft.OpenApi.Models;
using MU.WebApi.Middlewares;
using System.Reflection;
using System.Text.Json.Serialization;

namespace MU.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                }); ;
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Million And Up Properties V1",
                    Description = "A technical test for get into in company Million And Up",
                });
            }); ;
            services.AddTransient<GloblalExceptionHandlingMiddleware>();
            return services;
        }
    }
}
