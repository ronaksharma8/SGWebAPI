using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Search
{
    public class SearchTextListSearch : BaseListSearch, ISearchTextListSearch
    {
        public string? SearchText { get; set; }
    }
}
