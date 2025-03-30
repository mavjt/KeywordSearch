


using KeywordSearch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KeywordSearch.Infrastructure.Repos
{
    public class SearchHistoryRepository : ISearchHistoryRepository
    {
        private readonly HistoryContext db;

        public SearchHistoryRepository(HistoryContext db)
        {
            this.db = db;
        }
        public IQueryable<SearchHistory> GetAll()
        {
            return  db.SearchHistories;
        }

        public async Task Save(SearchHistory search)
        {
            
        }
    }
}
