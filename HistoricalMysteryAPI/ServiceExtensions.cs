using HM.Common;
using HM.DataAccess.DB;
using HM.LogicContainers;
using Microsoft.Extensions.DependencyInjection;

namespace HistoricalMysteryAPI
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }

        public static void ConfigureDependencyInjections(this IServiceCollection services)
        {
            services.ConfigureCommonDi();
            services.ConfigureRepositoryDi();
            services.ConfigureServicesDi();
        }
    }
}