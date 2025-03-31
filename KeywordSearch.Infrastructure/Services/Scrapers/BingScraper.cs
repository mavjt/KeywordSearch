using Microsoft.Extensions.Hosting;
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
        public BingScraper(ILogger<BingScraper> logger, IHostEnvironment hostingEnvironment) : base(logger, hostingEnvironment, "https://www.bing.com/")
        {
            
        }


        public async override Task<IEnumerable<int>> ProcessAsync(string keywords, string urlToFind)
        {
            _logger.LogInformation($"Starting {nameof(BingScraper)}");

            var SearchUrl = $"{_EngineBaseUrl}search?q={HttpUtility.UrlEncode(keywords)}&count={_MaxResults}";  //https://www.bing.com/search?q=insurance&count=100&pq=insurance

            var rawHTML = await CallUrl(SearchUrl);

            _logger.LogDebug($"{rawHTML}");

            string LinkClassMatch = "tilk";

            var links = ExtractLinksByClass(rawHTML, LinkClassMatch);
            _logger.LogInformation("{0} links found in the content", links.Count);

            List<int> ranking = GetMatchingIndexList(urlToFind, links);
            return ranking ?? [0];


        }

        
    }
}
