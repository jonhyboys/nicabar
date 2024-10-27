using Domain.Sales;

namespace Application.Sales
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public Guid Add(SaleAddModel saleAddModel)
        {
            Guid id;
            if(saleAddModel.Sale != null)
            {
                id = saleAddModel.Sale ?? Guid.NewGuid();
                _saleRepository.AddOrder(new Order()
                {
                    Id = Guid.NewGuid(),
                    Products = saleAddModel.Order.Products,
                    Note = ""
                }, id);
            }
            else
            {
                id = Guid.NewGuid();
                saleAddModel.Order.Id = Guid.NewGuid();
                _saleRepository.Add(new Sale()
                {
                    Id = id,
                    Table = saleAddModel.Table,
                    Orders = [saleAddModel.Order]
                });
            }
            return id;
        }
    }
}
