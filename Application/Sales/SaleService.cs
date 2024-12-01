using Application.Products;
using Domain.Entities.Products;
using Domain.Products;
using Domain.Sales;
using Domain.Tables;

namespace Application.Sales
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IProductRepository _productRepository;

        public SaleService(ISaleRepository saleRepository,
            ITableRepository tableRepository,
            IProductRepository productRepository)
        {
            _saleRepository = saleRepository;
            _tableRepository = tableRepository;
            _productRepository = productRepository;
        }

        public IEnumerable<InvoiceViewModel> GetAllUnpayed()
        {
            IEnumerable<Sale> unpayedSales = _saleRepository.GetAllUnpayed();
            IEnumerable<Table> tables = _tableRepository.GetAll();
            IEnumerable<Product> products = _productRepository.GetAll();
            IEnumerable<InvoiceViewModel> result = unpayedSales.Select(sale => new InvoiceViewModel()
            {
                Id = sale.Id,
                Table = sale.Table,
                TableName = "Mesa " + tables.FirstOrDefault(t => t.Id == sale.Table)?.Name.ToString(),
                Products = sale.Orders.SelectMany(order => order.Products)
                                        .GroupBy(po => po.Product)
                                        .Select(g => {
                                            var product = products.FirstOrDefault(p => p.Id == g.Key);
                                            var quantity = g.Sum(po => po.Quantity);
                                            if (product == null)
                                            {
                                                return new ProductSaleViewModel();
                                            }
                                            return new ProductSaleViewModel()
                                            {
                                                Id = product.Id,
                                                Name = product.Name,
                                                Quantity = quantity,
                                                Price = product.Price,
                                                SubTotal = product.Price * quantity
                                            };
                                        }).ToList(),
                Total = sale.Orders.SelectMany(order => order.Products)
                           .Sum(po => products.FirstOrDefault(p => p.Id == po.Product).Price * po.Quantity)
            });
            return result;
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

        public Guid Pay(Guid id)
        {
            Sale sale = _saleRepository.GetById(id);
            sale.Payed = true;
            if (_saleRepository.Update(sale)) { return sale.Id; }
            return Guid.Empty;
        }
    }
}
