using KeywordSearch.Core.Types;

namespace KeywordSearch.Core.Interfaces;

public interface ISearchScraperService
{
    Task StartSearch(string keywords, string UrlToMatch, List<string> searchEngine);
}
