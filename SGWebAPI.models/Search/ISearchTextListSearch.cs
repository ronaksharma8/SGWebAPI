using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Search
{
    public interface ISearchTextListSearch : IBaseListSearch
    {
        string SearchText { get; set; }
    }
}
