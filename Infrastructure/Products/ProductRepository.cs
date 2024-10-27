using Domain.Entities.Products;
using Domain.Products;
using System.Text.Json;

namespace Infrastructure.Products
{
    public class ProductRepository : IProductRepository
    {
        const string FILE_PATH = "Productos.json";

        public Product GetById(Guid id)
        {
            var products = GetAll().ToList();
            return products.Find(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            if (File.Exists(FILE_PATH))
            {
                var jsonData = File.ReadAllText(FILE_PATH);
                return JsonSerializer.Deserialize<List<Product>>(jsonData);
            }
            return [];
        }

        public bool Add(Product product)
        {
            var products = GetAll().ToList();
            products.Add(product);
            Save(products);
            return true;
        }

        public bool Delete(Guid id)
        {
            var products = GetAll().ToList();
            var product = products.Find(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
                Save(products);
            }
            return true;
        }

        public bool Update(Product product)
        {
            var products = GetAll().ToList();
            var index = products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                products[index] = product;
                Save(products);
            }
            return true;
        }

        private void Save(List<Product> products)
        {
            var jsonData = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILE_PATH, jsonData);
        }
    }
}
