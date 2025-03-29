using KeywordSearch.Server;
using Microsoft.AspNetCore.Mvc;
using KeywordSearch.Core.Interfaces;
using KeywordSearch.Infrastructure.DTOs;
using KeywordSearch.Core.Types;

namespace KeywordSearch.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchEngineLookupController : ControllerBase
    {
        private readonly ISearchScraperService _searchScraperService;
        private readonly ILogger<SearchEngineLookupController> _logger;
        public SearchEngineLookupController(ISearchScraperService searchScraperService, ILogger<SearchEngineLookupController> logger)
        {
            this._searchScraperService = searchScraperService;
            this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> StartAsync(SearchRequestDto requestDto)
        {
            _logger.LogDebug("StartAsync called {@0}", requestDto);
            await _searchScraperService.StartSearch(requestDto.Keywords, requestDto.Url, requestDto.SearchEngines);
            

            return NoContent();
        }

        [HttpGet]
        public IEnumerable<string> GetAvailableSearchEngines()
        {
            _logger.LogWarning("GetAvailableSearchEngines called ");
            return SearchEngine.List.Select(o => o.Name);

        }
    }
}
