using Microsoft.Extensions.Logging;
using Flurl.Http;
using System.Reflection.PortableExecutable;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;


namespace KeywordSearch.Infrastructure.Services.Scrapers
{
    public abstract class BaseScraper
    {
        protected readonly ILogger<BaseScraper> _logger;
        protected readonly IHostEnvironment hostingEnvironment;
        //private readonly SearchEngineConfig searchEngineOptions;
        
        protected int _MaxResults;
        protected  EngineConfig config;
        //protected HttpClient client;

        protected BaseScraper(ILogger<BaseScraper> logger, IHostEnvironment hostingEnvironment, IOptions<SearchEngineConfig> searchEngineOptions)
        {
            this._logger = logger;
            this.hostingEnvironment = hostingEnvironment;
            //this.searchEngineOptions = searchEngineOptions.Value;            
            _MaxResults = searchEngineOptions.Value.SearchItemsMax;
           
        }

        
        public abstract Task<IEnumerable<int>> ProcessAsync(string keywords, string url);

        protected static List<int> GetMatchingIndexList(string urlToFind, List<string> links)
        {
            return Enumerable.Range(0, links.Count)
                            .Where(i => links[i].Contains(urlToFind, StringComparison.InvariantCultureIgnoreCase))
                            .ToList();
        }
        protected static List<string> ExtractElementByClass(string html, string elementName, string className)
        {
            // Regular expression to match <className> tags with the specific class
            string pattern = $"<{elementName}[^>]*class=[\"'][^\"']*{className}[^\"']*[\"'][^>]*>[(\\s\\S)]*?<\\/{elementName}>";

            var matches = Regex.Matches(html, pattern);
            Console.WriteLine(matches);
            return matches.Select(x => x.Value).ToList();
        }

        protected static List<string> ExtractElements(string html, string elementName)
        {
            // Regular expression to match all <className> tags 
            string pattern = $"<{elementName}[^>]*[^>]*>[(\\s\\S)]*?<\\/{elementName}>";

            var matches = Regex.Matches(html, pattern);
            Console.WriteLine(matches);
            return matches.Select(x => x.Value).ToList();
        }

        protected async Task<string> GetSearchResults(string url) 
        {
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
}
