
namespace KeywordSearch.Infrastructure.Data;

public static class Mappings
{
    public static SearchHistoryDto Map(this SearchHistory searchHistory)
    {
        return new SearchHistoryDto( searchHistory.Keywords, searchHistory.Url,searchHistory.SearchCompleted, searchHistory.SearchEngine, searchHistory.Result);
    }
}
