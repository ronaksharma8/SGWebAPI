using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Search
{
    public abstract class BaseListSearch : IBaseListSearch
    {
        private int _pageNo;
        private int _pageSize;
        private string _sortBy;

        public int PageSize
        {
            get => _pageSize <= 0 ? DefaultPageSize : _pageSize;
            set => _pageSize = value;
        }

        public int PageNo
        {
            get => _pageNo <= 0 ? DefaultPageNumber : _pageNo;
            set => _pageNo = value;
        }

        public string SortBy
        {
            get => string.IsNullOrWhiteSpace(_sortBy) ? DefaultSortColumnName : _sortBy;
            set => _sortBy = value;
        }

        protected virtual string DefaultSortColumnName => string.Empty;
        protected virtual int DefaultPageNumber => 1;
        protected virtual int DefaultPageSize => 50;
    }
}
