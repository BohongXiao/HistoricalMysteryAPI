using HM.Common.Utils;
using HM.DataAccess.DB;
using HM.Interfaces.IRepositories;
using HM.Interfaces.IServices;
using HM.Interfaces.IUtils;
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
            services.AddSingleton<ILoggingService, LoggingService>();
            services.ConfigureRepositoryDi();
            services.ConfigureServicesDi();
        }

        public static void ConfigureRepositoryDi(this IServiceCollection services)
        {
            services.AddScoped<ITestRepo, TestRepo>();
        }

        public static void ConfigureServicesDi(this IServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();
        }
    }
}