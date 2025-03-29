using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace KeywordSearch.Infrastructure.Services.Scrapers
{
    internal class BingScraper : BaseScraper
    {
        public BingScraper(ILogger<BingScraper> logger) : base(logger, "https://www.bing.com")
        {
            
        }


        public async override Task<IEnumerable<int>> ProcessAsync(string keyword, string url)
        {
            _logger.LogInformation($"Starting {nameof(BingScraper)}");
            //Configuration.GetSection("SearchItemsMax").Value ?? 100;   //or better in abstract?
            return [1]; //  return indices.Count != 0 ? indices : [0];
        }
        
    }
}
