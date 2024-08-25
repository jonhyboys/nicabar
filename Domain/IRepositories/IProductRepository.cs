namespace Domain.Products
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(Guid id);
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(Guid id);
    }
}
