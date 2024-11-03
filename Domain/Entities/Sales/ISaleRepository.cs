namespace Domain.Sales
{
    public interface ISaleRepository
    {
        bool Add(Sale sale);
        bool AddOrder(Order order, Guid saleId);
        IEnumerable<Sale> GetAllUnpayed();
        Sale GetById(Guid saleId);
        bool Update(Sale sale);
    }
}
