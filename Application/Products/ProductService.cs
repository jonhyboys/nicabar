using Domain.Entities.Products;
using Domain.Products;

namespace Application.Products
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = _productRepository.GetAll();
            if (products.Any()) { return products; }
            SetLocalProducts();
            return _productRepository.GetAll();
        }

        public Product GetById(Guid id) {
            return _productRepository.GetById(id);
        }

        public bool Add(ProductAddModel productAddModel) {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Category = productAddModel.Category,
                Name = productAddModel.Name,
                Description = productAddModel.Description,
                Presentation = productAddModel.Presentation,
                Measure = productAddModel.Measure,
                Cost = productAddModel.Cost,
                Price = productAddModel.Price,
                Quantity = productAddModel.Quantity
            };
            return _productRepository.Add(product);
        }

        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }

        public bool Delete(Guid id)
        {
            return _productRepository.Delete(id);
        }

        private void SetLocalProducts()
        {
            Add(new ProductAddModel() {
                Name = "Coca cola",
                Description = "Bebida carbonatada",
                Presentation = Guid.NewGuid(),
                Cost = 15,
                Price = 35,
                Quantity = 100,
                Measure = Guid.NewGuid(),
                Category = Guid.Parse("dc5e8755-1c50-415e-9f9e-2ddbade3e45b")
            });
            Add(new ProductAddModel() {
                Name = "Tostones",
                Description = "Comida",
                Presentation = Guid.NewGuid(),
                Cost = 50,
                Price = 150,
                Quantity = 10,
                Measure = Guid.NewGuid(),
                Category = Guid.Parse("8efd193f-5e23-4802-9351-d568a4b84286")
            });
            Add(new ProductAddModel() {
                Name = "Ron plata",
                Description = "Ron",
                Presentation = Guid.NewGuid(),
                Cost = 75,
                Price = 215,
                Quantity = 80,
                Measure = Guid.NewGuid(),
                Category = Guid.Parse("09dbf864-fc95-4b8d-8873-a826deef7b57")
            });
            Add(new ProductAddModel() {
                    Name = "Toña",
                    Description = "Cerveza",
                    Presentation = Guid.NewGuid(),
                    Cost = 15,
                    Price = 35,
                    Quantity = 280,
                    Measure = Guid.NewGuid(),
                    Category = Guid.Parse("09dbf864-fc95-4b8d-8873-a826deef7b57")
            });
            Add(new ProductAddModel()
            {
                Name = "Limonada",
                Description = "Refresco",
                Presentation = Guid.NewGuid(),
                Cost = 15,
                Price = 35,
                Quantity = 280,
                Measure = Guid.NewGuid(),
                Category = Guid.Parse("dc5e8755-1c50-415e-9f9e-2ddbade3e45b")
            });
        }
    }
}
