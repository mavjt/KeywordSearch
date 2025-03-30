using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordSearch.Infrastructure.DTOs
{
    public record SearchHistoryDto(string Keywords, string Url, DateTime SearchDate, string SearchEngine, string Results);
   
}
