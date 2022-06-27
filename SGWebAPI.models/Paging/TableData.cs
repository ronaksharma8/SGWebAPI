using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Paging
{
    public class TableData<T> : ListData<T>
    {
        public IList<TableColumn> Columns
        {
            get;
            set;
        }

        public TableData()
            : this(TableColumn.CreateDynamicColumnsByList(typeof(T)))
        {
        }

        public TableData(IList<TableColumn> columns)
        {
            Columns = columns;
        }

        public TableData(IList<TableColumn> columns, IList<T> list) : base(list)
        {
            Columns = columns;
        }

        public TableData(IList<TableColumn> columns, int capacity) : base(capacity)
        {
            Columns = columns;
        }
    }
}
