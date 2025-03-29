using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordSearch.Infrastructure.Services.Scrapers
{
    internal class GoogleScraper : BaseScraper
    {
        
        public GoogleScraper(ILogger<GoogleScraper> logger) : base(logger, "https://www.google.com")
        {
            
        }
        public async override Task<IEnumerable<int>> ProcessAsync(string keyword, string url)
        {
            _logger.LogInformation($"Starting {nameof(GoogleScraper)}");
            return [3];
        }
    }
}
