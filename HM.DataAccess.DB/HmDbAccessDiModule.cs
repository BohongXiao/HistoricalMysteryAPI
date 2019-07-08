using HM.Interfaces.IRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace HM.DataAccess.DB
{
    public static class HmDbAccessDiModule
    {
        public static void ConfigureRepositoryDi(this IServiceCollection services)
        {
            services.AddScoped<ITestRepo, TestRepo>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
        }
    }
}