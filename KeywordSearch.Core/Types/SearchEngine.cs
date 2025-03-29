namespace KeywordSearch.Core.Types;


public class SearchEngine : SmartEnum<SearchEngine>
{
    public static readonly SearchEngine Google = new(nameof(Google), 1);
    public static readonly SearchEngine Bing = new(nameof(Bing), 2);

    protected SearchEngine(string name, int value) : base(name, value) { }
}
