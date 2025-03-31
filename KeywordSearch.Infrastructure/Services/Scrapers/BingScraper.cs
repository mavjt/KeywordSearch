using Flurl;
using KeywordSearch.Core.Interfaces;
using KeywordSearch.Core.Types;


namespace KeywordSearch.Infrastructure.Services.Scrapers;

internal class BingScraper : BaseScraper
{
    
    public BingScraper(ILogger<BingScraper> logger, IHostEnvironment hostingEnvironment, IOptions<SearchEngineConfig> searchEngineOptions, IHTMLParser hTMLParser) 
        : base(logger, hostingEnvironment, searchEngineOptions, hTMLParser, SearchEngine.Bing)
    {

        
       
    }


    public async override Task<IEnumerable<int>> ProcessAsync(string keywords, string urlToFind)
    {
        _logger.LogInformation($"Starting {nameof(BingScraper)}");
        


        var rawHTML = await RequestSearchResults(keywords);
        _logger.LogDebug($"{rawHTML}");

        var elements = hTMLParser.GetHtmlElement(rawHTML, config.ResultItemElement);
        _logger.LogInformation("{0} links found in the content", elements.Count);
        var rankingList = (from link in elements where link.Contains(urlToFind, StringComparison.OrdinalIgnoreCase) select elements.IndexOf(link)).Distinct().ToList();
        List<int> ranking = FindStringInList(urlToFind, elements);
        return ranking.Count > 0 ? ranking : [0];


    }

    
}
