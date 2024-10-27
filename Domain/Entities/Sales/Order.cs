namespace Domain.Sales
{
    public class Order
    {
        public Guid? Id { get; set; }
        public IEnumerable<ProductOrder> Products { get; set; }
        public string? Note { get; set; }
    }
}
