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

        public IList<TableColumn> OrderColumns
        {
            get;
            set;
        }
    }
}
