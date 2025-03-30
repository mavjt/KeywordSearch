using System.ComponentModel.DataAnnotations;

namespace KeywordSearch.Infrastructure.DTOs;

public record SearchRequestDto([Required] string Keywords, [Required] string Url, List<string> SearchEngines);
//todo make a URL type for better matching
