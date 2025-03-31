using Flurl;
using KeywordSearch.Core.Types;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        
        public BingScraper(ILogger<BingScraper> logger, IHostEnvironment hostingEnvironment, IOptions<SearchEngineConfig> searchEngineOptions) : base(logger, hostingEnvironment, searchEngineOptions)
        {

            config = searchEngineOptions.Value.GetEngineConfig(SearchEngine.Bing.Name);
           
        }


        public async override Task<IEnumerable<int>> ProcessAsync(string keywords, string urlToFind)
        {
            _logger.LogInformation($"Starting {nameof(BingScraper)}");

            
            var SearchUrl = String.Format(config.SearchUrl, HttpUtility.UrlEncode(keywords), _MaxResults);
            //var SearchUrl = $"{_EngineBaseUrl}search?q={HttpUtility.UrlEncode(keywords)}&count={_MaxResults}";  //https://www.bing.com/search?q=insurance&count=100&pq=insurance

            var rawHTML = await GetSearchResults(SearchUrl);
            _logger.LogDebug($"{rawHTML}");

            var elements = ExtractElements(rawHTML, config.ResultItemElement);
            _logger.LogInformation("{0} links found in the content", elements.Count);

            List<int> ranking = GetMatchingIndexList(urlToFind, elements);
            return ranking.Count < 1 ? [0] : ranking;


        }

        
    }
}
