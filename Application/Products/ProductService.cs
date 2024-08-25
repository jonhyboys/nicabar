using Domain.Products;

namespace Application.Products
{
    internal class ProductService : IProductService
    {
        public IEnumerable<Product> GetAll()
        {
            return GetLocalProducts();
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
