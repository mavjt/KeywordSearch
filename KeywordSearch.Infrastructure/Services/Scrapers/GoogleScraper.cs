using KeywordSearch.Core.Types;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;
using System.Web;

namespace KeywordSearch.Infrastructure.Services.Scrapers
{
    internal class GoogleScraper : BaseScraper
    {
        
        public GoogleScraper(ILogger<GoogleScraper> logger, IHostEnvironment hostingEnvironment, IOptions<SearchEngineConfig> searchEngineOptions) : base(logger, hostingEnvironment, searchEngineOptions)
        {
            config = searchEngineOptions.Value.GetEngineConfig(SearchEngine.Google.Name);
        }
        public async override Task<IEnumerable<int>> ProcessAsync(string keywords, string urlToFind)
        {
            _logger.LogInformation($"Starting {nameof(GoogleScraper)}");

            var SearchUrl = String.Format(config.SearchUrl, HttpUtility.UrlEncode(keywords), _MaxResults);
            
            
            var rawHTML = hostingEnvironment.IsDevelopment() ?  CallUrlMOCK("dummygoogleresult.html") : (await GetSearchResults(SearchUrl));  //GOOGLE IS BLOCKING THIS FROM CODE
            _logger.LogDebug($"{rawHTML}");
            

            var links = ExtractElementByClass(rawHTML, config.ResultItemElement, config.ResultItemClass);
            _logger.LogInformation("{0} links found in the content", links.Count);

            List<int> ranking = GetMatchingIndexList(urlToFind, links);
            return ranking.Count < 1 ? [0] : ranking;
        }
        
        
       
    }
}
