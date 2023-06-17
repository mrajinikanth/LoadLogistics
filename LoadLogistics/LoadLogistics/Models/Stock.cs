namespace LoadLogistics.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public Warehouse Warehouse { get; set; }
        public FreightItem FreightItem { get; set; }
        public int StockQuantity { get; set; }
    }
}
