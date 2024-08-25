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
            return _productRepository.GetAll();
        }

        public Product GetById(Guid id) {
            return _productRepository.GetById(id);
        }

        public bool Add(ProductAddModel productAddModel) {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = productAddModel.Name,
                Description = productAddModel.Description,
                Presentation = productAddModel.Presentation,
                Measure = Guid.NewGuid(),
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

        private IEnumerable<Product> GetLocalProducts()
        {
            return new List<Product>() {
                new Product() { 
                    Id = new Guid(),
                    Name = "Coca cola",
                    Description = "Bebida carbonatada",
                    Presentation = "Lata",
                    Cost = 15,
                    Price = 35,
                    Quantity = 100,
                    Measure = new Guid()
                },
                new Product() {
                    Id = new Guid(),
                    Name = "Tostones",
                    Description = "Comida",
                    Presentation = "Servicio",
                    Cost = 50,
                    Price = 150,
                    Quantity = 10,
                    Measure = new Guid()},
                new Product() {
                    Id = new Guid(),
                    Name = "Ron plata",
                    Description = "Bebida alcohólica",
                    Presentation = "Media",
                    Cost = 75,
                    Price = 215,
                    Quantity = 80,
                    Measure = new Guid()}
            };
        }
    }
}
