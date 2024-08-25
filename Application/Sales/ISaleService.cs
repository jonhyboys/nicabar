using Domain.Sales;

namespace Application.Sales
{
    public interface ISaleService
    {
        bool Add(SaleAddModel saleAddModel);
    }
}
