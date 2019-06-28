using HM.Common.Utils;
using HM.Interfaces.IUtils;
using Microsoft.Extensions.DependencyInjection;

namespace HM.Common
{
    public static class HmCommonDiModule
    {
        public static void ConfigureCommonDi(this IServiceCollection services)
        {
            services.AddSingleton<ILoggingService, LoggingService>();
        }
    }
}