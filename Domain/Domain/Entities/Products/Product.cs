namespace Domain.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Presentation { get; set; }
        public Guid Measure { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
