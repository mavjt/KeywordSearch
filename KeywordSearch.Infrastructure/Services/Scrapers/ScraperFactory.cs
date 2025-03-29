using KeywordSearch.Core.Types;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace KeywordSearch.Infrastructure.Services.Scrapers
{
    public  class ScraperFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ScraperFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public BaseScraper Create(SearchEngine searchEngine) {

            //var type = System.Type.GetType($"{nameof(KeywordSearch.Infrastructure.Services.Scrapers)}.{searchEngine.Name}Scraper");
            //return _serviceProvider.GetRequiredService<IScraper>(type);

            //todo smarten up
            if (searchEngine == SearchEngine.Google)
                return (BaseScraper)_serviceProvider.GetRequiredService(typeof(GoogleScraper));

            return (BaseScraper)_serviceProvider.GetRequiredService(typeof(BingScraper));

        }
    }
}
