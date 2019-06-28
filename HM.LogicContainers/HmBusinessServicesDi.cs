using HM.Interfaces.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace HM.LogicContainers
{
    public static class HmBusinessServicesDi
    {
        public static void ConfigureServicesDi(this IServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();
        }
    }
}