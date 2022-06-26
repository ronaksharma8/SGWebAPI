using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Search
{
    public interface IBaseListSearch
    {
        int PageSize { get; set; }
        int PageNo { get; set; }
        string SortBy { get; set; }
    }
}
