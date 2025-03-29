using KeywordSearch.Core.Interfaces;
using KeywordSearch.Infrastructure;
using KeywordSearch.Infrastructure.Interfaces;
using KeywordSearch.Infrastructure.Repos;
using KeywordSearch.Infrastructure.Services.Scrapers;

namespace KeywordSearch.Web.Config
{
    public static class ServiceConfigs
    {
        public static IServiceCollection AddServiceConfigs(this IServiceCollection services,  WebApplicationBuilder builder)
        {
            
            //builder.Services.AddHttpClient<IScraper>();
            builder.Services.AddTransient<ScraperFactory>();
            builder.Services.AddScoped<ISearchScraperService, SearchScraperService>();
            builder.Services.AddScoped<ISearchHistoryRepository, SearchHistoryRepository>();
            services.RegisterProductImporterLogic();
            


            return services;
        }
    }

}
