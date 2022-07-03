using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Paging
{
    public class PagedList<T> : TableData<T>, IPagedList<T>
    {
        public int TotalCount { get; private set; }

        public int PageSize { get; private set; }

        public int TotalPages { get; private set; }

        public int PageNo { get; private set; }

        public int StartRecord { get; private set; }


        public PagedList(IList<T> pagedItems, int totalCount, int pageSize, int totalPages, int pageNo, int startRecord, Type concreteType = null)
            : base(null)
        {
            this.Columns = concreteType == null
                ? TableColumn.CreateDynamicColumnsByList(typeof(T))
                : TableColumn.CreateDynamicColumnsByType(concreteType);

            this.OrderColumns = TableColumn.CreateDynamicColumnsByList(typeof(Order));

            Items = pagedItems.ToList();

            TotalCount = totalCount;
            PageSize = pageSize;
            TotalPages = totalPages;
            PageNo = pageNo;
            StartRecord = startRecord;
        }
    }
}
