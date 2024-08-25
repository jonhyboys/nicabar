namespace Domain.Products
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }
}
