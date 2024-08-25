namespace Application.Sales
{
    public class SaleAddModel
    {
        public int Table { get; set; }
        public Guid Product { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
    }
}
