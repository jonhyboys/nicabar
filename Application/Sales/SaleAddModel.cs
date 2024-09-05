namespace Application.Sales
{
    public class SaleAddModel
    {
        public Guid Table { get; set; }
        public Guid Product { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
    }
}
