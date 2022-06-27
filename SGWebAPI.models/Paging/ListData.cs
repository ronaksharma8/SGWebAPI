using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Paging
{
    public class ListData<T>
    {
        public IList<T> Items { get; set; }

        public ListData()
        {
            Items = new List<T>();
        }
        public ListData(IList<T> list)
        {
            Items = list;
        }

        public ListData(int capacity)
        {
            Items = new List<T>(capacity);
        }
    }
}
