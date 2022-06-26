using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models
{
    public class CreateOrderResponse
    {
        public OrderType OrderType { get; set; }
        public Guid StockId { get; set; }
        public string StockCode { get; set; }
        public ExecutionMode ExecutionMode { get; set; }
        public double OrderPrice { get; set; }
        public long Amount { get; set; }
    }
}
