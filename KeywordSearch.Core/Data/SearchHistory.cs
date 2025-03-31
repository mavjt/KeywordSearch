using KeywordSearch.Core.Types;

namespace KeywordSearch.Core.Data;

public class SearchHistory
{
    //public SearchHistory() { }
    public SearchHistory(string keywords, string url, string searchEngine, string result)
    {
        Keywords = keywords;
        Url = url;
        SearchEngine = searchEngine;
        //Result = String.Join(",", scrapeResult);
        Result = result;
        //SearchCompleted = DateTime.Now;
    }
    public int Id { get; set; }
    public string Keywords { get; set; } 
    public string Url { get; set; } 
    public DateTime SearchCompleted { get; set; } = DateTime.Now;
    public string SearchEngine { get; set; }
    public string Result { get; set; }

}
