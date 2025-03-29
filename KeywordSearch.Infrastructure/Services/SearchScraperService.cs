﻿using KeywordSearch.Core.Types;
using KeywordSearch.Infrastructure.Repos;
using KeywordSearch.Infrastructure.Services.Scrapers;

namespace KeywordSearch.Infrastructure.Interfaces;

public class SearchScraperService : ISearchScraperService
{
    private readonly ScraperFactory scraperFactory;
    private readonly ISearchHistoryRepository historyRepository;

    public SearchScraperService(ScraperFactory scraperFactory, ISearchHistoryRepository repo)
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
            await historyRepository.Save(new SearchHistory(keywords, UrlToMatch, engine, randResult));
        }

        

    }
}
