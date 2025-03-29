namespace KeywordSearch.Infrastructure.DTOs;

public record SearchRequestDto(string Keywords, string Url, List<string> SearchEngines);
//todo make a URL type for better matching
