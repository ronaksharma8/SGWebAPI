using SGWebAPI.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SGWebAPI.Models
{
    public class Stock
    {
        [ColumnHidden]
        [Key]
        public Guid StockId { get; set; }

        [ColumnOrder(0)]
        public string Currency { get; set; }

        [ColumnOrder(1)]
        [QueryProperty]
        public string Ric { get; set; }

        [ColumnOrder(2)]
        [QueryProperty]
        public string BloomerbergTicket { get; set; }

        [ColumnOrder(3)]
        [QueryProperty]
        public string BlommerbergTicketLocal { get; set; }

        [ColumnOrder(4)]
        [QueryProperty]
        public string Name { get; set; }

        [ColumnOrder(5)]
        [QueryProperty]
        public string Country { get; set; }

        [ColumnOrder(6)]
        [QueryProperty]
        public double Price { get; set; }
    }
}