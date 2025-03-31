using KeywordSearch.Core.Types;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace KeywordSearch.Infrastructure.Services.Scrapers
{
    public  class ConcreteScraperFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ConcreteScraperFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public BaseScraper Create(SearchEngine searchEngine) {

           
            //todo smarten up
            if (searchEngine == SearchEngine.Google)
                return (BaseScraper)_serviceProvider.GetRequiredService(typeof(GoogleScraper));

            return (BaseScraper)_serviceProvider.GetRequiredService(typeof(BingScraper));

        }
    }
}
