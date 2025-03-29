using Microsoft.Extensions.Logging;
using Flurl.Http;

namespace KeywordSearch.Infrastructure.Services.Scrapers
{
    public abstract class BaseScraper
    {
        protected readonly ILogger<BaseScraper> _logger;

        protected BaseScraper(ILogger<BaseScraper> logger, string host)
        {
            this._logger = logger;            
            _SearchUrl = host;
        }

        //protected string Hostname { get; set; }
        private readonly string _SearchUrl;
        public abstract Task<IEnumerable<int>> ProcessAsync(string keyword, string url);

        async Task<string> CallUrl(string url)
        {
            _logger.LogInformation($"Calling url {url}");
            return await url.GetStringAsync();

        }
    }
}
