using KeywordSearch.Core.Interfaces;
using KeywordSearch.Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;
using KeywordSearch.Infrastructure.Data;

namespace KeywordSearch.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchHistoryController :ControllerBase
    {

        private readonly ILogger<SearchHistoryController> _logger;
        private readonly ISearchHistoryRepository _searchHistoryRepository;

        public SearchHistoryController(ILogger<SearchHistoryController> logger, ISearchHistoryRepository searchHistoryRepository)
        {
            
            this._logger = logger;
            this._searchHistoryRepository = searchHistoryRepository;
        }


        [HttpGet]
        public IEnumerable<SearchHistoryDto> Get()
        {
            _logger.LogDebug("GetHistory called ");
            return (_searchHistoryRepository.GetAll()).Select(o => o.Map());

        }
    }
}
