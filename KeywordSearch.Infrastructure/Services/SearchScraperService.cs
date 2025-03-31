using Flurl;
using KeywordSearch.Core.Types;
using KeywordSearch.Infrastructure.Repos;
using KeywordSearch.Infrastructure.Services.Scrapers;

namespace KeywordSearch.Infrastructure.Interfaces;

public class SearchScraperService : ISearchScraperService
{
    private readonly ConcreteScraperFactory scraperFactory;
    private readonly ISearchHistoryRepository historyRepository;

    public SearchScraperService(ConcreteScraperFactory scraperFactory, ISearchHistoryRepository repo)
    {
        this.scraperFactory = scraperFactory;
        this.historyRepository = repo;
    }
    public async Task StartSearch(string keywords, string UrlToMatch, List<string> searchEngineNames)
    {
        foreach (var searchEngineName in searchEngineNames)
        {
            SearchEngine engine;
            var validEngine= SearchEngine.TryFromName(searchEngineName, out engine);
            if (!validEngine)
                throw new ArgumentException($"{searchEngineName} is an unexpected search engine");

            var Scraper = scraperFactory.Create(engine);
            var randResult = await Scraper.ProcessAsync(keywords, UrlToMatch);

            var history = new SearchHistory {
                Keywords = keywords,
                Url = UrlToMatch,
                SearchEngine = engine.Name,
                Result = String.Join(",", randResult),
                SearchCompleted = DateTime.Now
            };
            await historyRepository.Save(history);
        }

        

    }
}
