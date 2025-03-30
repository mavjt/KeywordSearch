using KeywordSearch.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordSearch.Core.Interfaces
{
    public interface ISearchHistoryRepository
    {
        Task Save(SearchHistory search);
        IQueryable<SearchHistory> GetAll();
    }
}
