using KeywordSearch.Core.Interfaces;
using KeywordSearch.Core.Types;
using KeywordSearch.Infrastructure.DTOs;
using KeywordSearch.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace KeywordSearch.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeywordSearchController : ControllerBase
    {
        private readonly ISearchScraperService _searchScraperService;
        private readonly ILogger<KeywordSearchController> _logger;


        public KeywordSearchController(ISearchScraperService searchScraperService, ILogger<KeywordSearchController> logger, IHostEnvironment hostingEnvironment)
        {
            this._searchScraperService = searchScraperService;
            this._logger = logger;

        }

        [HttpPost]        
        public async Task<IActionResult> StartAsync(SearchRequestDto requestDto)
        {
            _logger.LogInformation("StartAsync called {@0}", requestDto);

            await _searchScraperService.StartSearch(requestDto.Keywords, requestDto.Url, requestDto.SearchEngines);            

            return Ok("Search complete");
        }

      
    }
}
