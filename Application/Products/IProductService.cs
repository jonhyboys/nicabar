using Domain.Products;

namespace Application.Products
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(Guid id);
        bool Add(ProductAddModel productAddModel);
        bool Update(Product product);
    }
}
