using KeywordSearch.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using KeywordSearch.Core.Interfaces;
using KeywordSearch.Infrastructure.DTOs;
using KeywordSearch.Core.Types;
using KeywordSearch.Core.Data;

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

        [HttpGet]
        public IEnumerable<SearchEngine> GetAvailableSearchEngines()
        {
            _logger.LogDebug("GetAvailableSearchEngines called ");
            return SearchEngine.List;

        }


       
    }
}
