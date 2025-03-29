using KeywordSearch.Infrastructure.Services.Scrapers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace KeywordSearch.Infrastructure
{
    public static class DIRegistrations
    {
        //https://medium.com/null-exception/factory-pattern-using-built-in-dependency-injection-of-asp-net-core-f91bd3b58665
        public static IServiceCollection RegisterProductImporterLogic(this IServiceCollection services)
        {
            services.AddTransient<GoogleScraper>()
                .AddTransient<BaseScraper, GoogleScraper>(s => s.GetRequiredService<GoogleScraper>());

            services.AddTransient<BingScraper>()
                        .AddTransient<BaseScraper, BingScraper>(s => s.GetRequiredService<BingScraper>());
            return services;
        }
    }
}
