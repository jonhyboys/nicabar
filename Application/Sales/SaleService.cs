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

        public bool Add(SaleAddModel saleAddModel)
        {
            Sale sale = new Sale() {
                Id = Guid.NewGuid(),
                Table = saleAddModel.Table,
                Product = saleAddModel.Product,
                Quantity = saleAddModel.Quantity,
                Note = saleAddModel.Note
            };
            return _saleRepository.Add(sale);
        }
    }
}
