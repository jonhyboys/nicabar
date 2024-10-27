using Domain.Sales;

namespace Application.Sales
{
    public class SaleAddModel
    {
        public Guid? Sale { get; set; }
        public Guid Table { get; set; }
        public Order Order { get; set; }
    }
}
