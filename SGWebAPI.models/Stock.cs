using SGWebAPI.Models.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SGWebAPI.Models
{
    public class Stock
    {
        [ColumnHidden]
        [Key]
        [ColumnOrder(1)]
        [ColumnName("stockId")]
        [ColumnWidth(160)]
        public Guid StockId { get; set; }

        [ColumnHidden]
        [ColumnOrder(2)]
        [QueryProperty]
        [ColumnWidth(160)]
        [ColumnName("ric")]
        public string Ric { get; set; }

        [ColumnHidden]
        [ColumnOrder(3)]
        [QueryProperty]
        [ColumnWidth(260)]
        [ColumnName("bloombergTicker")]
        public string BloombergTicker { get; set; }

        [ColumnOrder(4)]
        [QueryProperty]
        [ColumnWidth(260)]
        [ColumnName("bloombergTickerLocal")]
        [Description("Stock Code")]
        public string BloombergTickerLocal { get; set; }

        [ColumnOrder(5)]
        [QueryProperty]
        [ColumnWidth(160)]
        [ColumnName("price")]
        [Description("Market Price")]
        public double Price { get; set; }

        [ColumnOrder(6)]
        [ColumnWidth(160)]
        [ColumnName("currency")]
        public string Currency { get; set; }

        [ColumnHidden]
        [ColumnOrder(7)]
        [QueryProperty]
        [ColumnWidth(160)]
        [ColumnName("name")]
        public string Name { get; set; }

        [ColumnHidden]
        [ColumnOrder(8)]
        [QueryProperty]
        [ColumnWidth(160)]
        [ColumnName("country")]
        public string Country { get; set; }
    }
}