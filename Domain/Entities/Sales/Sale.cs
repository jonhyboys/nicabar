namespace Domain.Sales
{
    public class Sale
    {
        public Guid Id { get; set; }
        public Guid Table { get; set; }
        public List<Order> Orders { get; set; }
        public bool Payed { get; set; } = false;
    }
}
