using KeywordSearch.Core.Interfaces;
using KeywordSearch.Core.Types;
using Microsoft.AspNetCore.Mvc;

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
            _logger.LogInformation("GetAvailableSearchEngines called ");
            return SearchEngine.List;
           

        }


       
    }
}
