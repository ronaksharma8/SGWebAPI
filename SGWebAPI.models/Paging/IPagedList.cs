using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Paging
{
    public interface IPagedList<T>
    {
        IList<T> Items { get; }

        int TotalCount { get; }

        int PageSize { get; }

        int TotalPages { get; }

        int StartRecord { get; }

        int PageNo { get; }
    }
}
