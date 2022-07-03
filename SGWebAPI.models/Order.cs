using SGWebAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models
{
    public class Order
    {
        [ColumnOrder(1)]
        [QueryProperty]
        [ColumnWidth(130)]
        [ColumnName("orderType")]
        [Description("Side")]
        public OrderType OrderType { get; set; }

        [ColumnOrder(2)]
        [QueryProperty]
        [ColumnWidth(260)]
        [ColumnName("bloombergTickerLocal")]
        [Description("Stock Code")]
        public string BloombergTickerLocal { get; set; }


        [ColumnOrder(3)]
        [ColumnWidth(260)]
        [ColumnName("executionMode")]
        [Description("Execution Mode")]
        [ColumnEditable]
        [ColumnDataType(ColumnDataType.SingleSelect, new[] { "Market", "Limit" })]

        public ExecutionMode ExecutionMode { get; set; }

        [ColumnOrder(4)]
        [ColumnWidth(130)]
        [ColumnName("orderPrice")]
        [Description("Order Price")]
        [ColumnEditable]
        public double OrderPrice { get; set; }

        [ColumnOrder(5)]
        [ColumnWidth(160)]
        [ColumnName("currency")]
        [Description("Currency")]
        public string Currency { get; set; }

        [ColumnOrder(6)]
        [ColumnWidth(160)]
        [ColumnName("amount")]
        [Description("Amount(Shares)")]
        [ColumnEditable]
        public string Amount { get; set; }
    }
}
