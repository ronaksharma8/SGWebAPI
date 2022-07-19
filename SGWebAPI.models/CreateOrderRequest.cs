using SGWebAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models
{
    public class CreateOrderRequest
    {
        public OrderType OrderType { get; set; }
        public Guid StockId { get; set; }

        //[NoSpecificStockCode("388 HK")]
        public string StockCode { get; set; }
        public ExecutionMode ExecutionMode { get; set; }

        public double OrderPrice { get; set; }

        public long Amount { get; set; }
    }

    public enum OrderType
    {
        Buy = 0,
        Sell = 1,
    }

    public enum ExecutionMode
    {
        Limit = 0,
        Market = 1,
    }
}
