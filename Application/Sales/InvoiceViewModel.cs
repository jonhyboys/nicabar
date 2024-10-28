using Application.Products;

namespace Application.Sales
{
    public class InvoiceViewModel
    {
        public Guid Id { get; set; }
        public Guid Table { get; set; }
        public string TableName { get; set; }
        public IEnumerable<ProductSaleViewModel> Products { get; set; }
        public decimal Total { get; set; }
    }
}
