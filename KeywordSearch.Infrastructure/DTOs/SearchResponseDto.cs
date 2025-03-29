using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordSearch.Infrastructure.Data
{
    public record SearchResponseDto (IEnumerable<int> KeywordsRank);


   
}
