using System.Web;

namespace KeywordSearch.Infrastructure.Services.Scrapers;

public abstract class BaseScraper
{
    protected readonly ILogger<BaseScraper> _logger;
    protected readonly IHostEnvironment hostingEnvironment;
    protected readonly IHTMLParser hTMLParser;
    protected int _MaxResults;
    protected  EngineConfig config;
    protected string SearchUrl(string keywords) => String.Format(config.SearchUrl, HttpUtility.UrlEncode(keywords), _MaxResults);

    protected BaseScraper(ILogger<BaseScraper> logger, IHostEnvironment hostingEnvironment, IOptions<SearchEngineConfig> searchEngineOptions, IHTMLParser hTMLParser, SearchEngine searchEngine)
    {
        this._logger = logger;
        this.hostingEnvironment = hostingEnvironment;
        this.hTMLParser = hTMLParser;
        _MaxResults = searchEngineOptions.Value.SearchItemsMax;
        config = searchEngineOptions.Value.GetEngineConfig(searchEngine);
    }

    
    public abstract Task<IEnumerable<int>> ProcessAsync(string keywords, string url);

    protected static List<int> FindStringInList(string urlToFind, List<string> links) => Enumerable.Range(1, links.Count)
                        .Where(i => links[i].Contains(urlToFind, StringComparison.InvariantCultureIgnoreCase))
                        .ToList();


    protected async Task<string> RequestSearchResults(string keywords) 
    {
        var url = SearchUrl(keywords);
        _logger.LogInformation($"Calling url {url}");
        var rawHTML = await url.WithHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:136.0) Gecko/20100101 Firefox/136.0").GetStringAsync();
        _logger.LogDebug($"{rawHTML}");
        return rawHTML;
    }



    protected string CallUrlMOCK(string filename)
    {
        _logger.LogInformation($"Calling MOCK url {filename}");   
        
        var path = $"{hostingEnvironment.ContentRootPath}\\{filename}";
        return System.IO.File.ReadAllText(path); 
    }
}
