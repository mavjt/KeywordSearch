using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordSearch.Infrastructure.Services
{
    public class SearchEngineConfig
    {
        public int SearchItemsMax { get; set; }
        public List<EngineConfig> Engines { get; set; } = new List<EngineConfig>();
        public EngineConfig GetEngineConfig(string Name) { return Engines.Single(o => o.Name == Name); }
    }


    public class EngineConfig
    {
        public string Name { get; set; } = string.Empty;
        public string SearchUrl {  get; set; } = string.Empty;
        public string ResultItemClass { get; set; } = string.Empty;
        public string ResultItemElement { get; set; } = string.Empty;
    }

    
}
