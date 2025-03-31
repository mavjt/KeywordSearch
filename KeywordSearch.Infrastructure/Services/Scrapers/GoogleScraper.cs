using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using System.Web;

namespace KeywordSearch.Infrastructure.Services.Scrapers
{
    internal class GoogleScraper : BaseScraper
    {
        
        public GoogleScraper(ILogger<GoogleScraper> logger, IHostEnvironment hostingEnvironment) : base(logger, hostingEnvironment,  "https://www.google.com/")
        {
            
        }
        public async override Task<IEnumerable<int>> ProcessAsync(string keywords, string urlToFind)
        {
            _logger.LogInformation($"Starting {nameof(GoogleScraper)}");
            
            var SearchUrl = $"{_EngineBaseUrl}search?q={HttpUtility.UrlEncode(keywords)}&num={_MaxResults}";
            
            var rawHTML = hostingEnvironment.IsDevelopment() ?  CallUrlMOCK("dummygoogleresult.html") : (await CallUrl(SearchUrl));  //GOOGLE IS BLOCKING THIS FROM CODE

            _logger.LogDebug($"{rawHTML}");

            string LinkClassMatch = "zReHs";

            var links = ExtractLinksByClass(rawHTML, LinkClassMatch);
            _logger.LogInformation("{0} links found in the content", links.Count);




            List<int> ranking = GetMatchingIndexList(urlToFind, links);
            return ranking ?? [0];
        }
        
        
       
    }
}
