namespace SGWebAPI.Models
{
    public class Stock
    {
        public Guid StockId { get; set; }
        public string Currency { get; set; }
        public string Ric { get; set; }
        public string BloomerbergTicket { get; set; }
        public string BlommerbergTicketLocal { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double Price { get; set; }
    }
}