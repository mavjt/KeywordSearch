using KeywordSearch.Core.Interfaces;
using KeywordSearch.Infrastructure;
using KeywordSearch.Infrastructure.Data;
using KeywordSearch.Infrastructure.Interfaces;
using KeywordSearch.Infrastructure.Repos;
using KeywordSearch.Infrastructure.Services.Scrapers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using KeywordSearch.Infrastructure.Services;

namespace KeywordSearch.Web.Config
{
    public static class ServiceConfigs
    {
        public static IServiceCollection AddServiceConfigs(this IServiceCollection services, IConfiguration configuration, WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<HistoryContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(HistoryContext))));

            services.Configure<SearchEngineConfig>(configuration.GetSection("SearchEngineConfig"));


            builder.Services.AddHttpClient<BaseScraper>();
            builder.Services.AddScoped<IHTMLParser, HTMLParser>();
            builder.Services.AddTransient<ConcreteScraperFactory>();
            builder.Services.AddScoped<ISearchScraperService, SearchScraperService>();
            builder.Services.AddScoped<ISearchHistoryRepository, SearchHistoryRepository>();
            services.RegisterProductImporterLogic();
            


            return services;
        }
    }

}
