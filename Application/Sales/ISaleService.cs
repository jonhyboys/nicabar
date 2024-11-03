namespace Application.Sales
{
    public interface ISaleService
    {
        Guid Add(SaleAddModel saleAddModel);
        IEnumerable<InvoiceViewModel> GetAllUnpayed();
        Guid Pay(Guid id);
    }
}
