namespace Domain.Products
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        bool Add(Product product);
    }
}
