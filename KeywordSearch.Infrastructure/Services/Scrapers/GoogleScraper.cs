

namespace KeywordSearch.Infrastructure.Services.Scrapers
{
    internal class GoogleScraper : BaseScraper
    {
        
        public GoogleScraper(ILogger<GoogleScraper> logger, IHostEnvironment hostingEnvironment, IOptions<SearchEngineConfig> searchEngineOptions, IHTMLParser hTMLParser) 
            : base(logger, hostingEnvironment, searchEngineOptions,hTMLParser, SearchEngine.Google)
        {
            
        }
        public async override Task<IEnumerable<int>> ProcessAsync(string keywords, string urlToFind)
        {
            _logger.LogInformation($"Starting {nameof(GoogleScraper)}");

            
            
            
            var rawHTML = hostingEnvironment.IsDevelopment() ?  CallUrlMOCK("dummygoogleresult.html") : (await RequestSearchResults(keywords));  //GOOGLE IS BLOCKING THIS FROM CODE
            _logger.LogDebug($"{rawHTML}");
            

            var links = hTMLParser.GetHtmlElement(rawHTML, config.ResultItemElement, config.ResultItemClass);  //ExtractElementByClass(rawHTML, config.ResultItemElement, config.ResultItemClass);
            _logger.LogInformation("{0} links found in the content", links.Count);

            List<int> ranking = FindStringInList(urlToFind, links);
            return ranking.Count > 0  ? ranking :[0] ;
        }
        
        
       
    }
}
