using Domain.Sales;
using System.Text.Json;

namespace Infrastructure.Sales
{
    public class SaleRepository : ISaleRepository
    {
        const string FILE_PATH = "Sales.json";

        public Sale GetById(Guid id)
        {
            var sales = GetAll().ToList();
            return sales.Find(p => p.Id == id);
        }

        public IEnumerable<Sale> GetAll()
        {
            if (File.Exists(FILE_PATH))
            {
                var jsonData = File.ReadAllText(FILE_PATH);
                return JsonSerializer.Deserialize<List<Sale>>(jsonData);
            }
            return [];
        }

        public bool Add(Sale sale)
        {
            var sales = GetAll().ToList();
            sales.Add(sale);
            Save(sales);
            return true;
        }

        public bool AddOrder(Order order, Guid saleId)
        {
            Sale sale = GetById(saleId);
            sale.Orders.Add(order);
            Update(sale);
            return true;
        }

        public bool Delete(Guid id)
        {
            var sales = GetAll().ToList();
            var sale = sales.Find(p => p.Id == id);
            if (sale != null)
            {
                sales.Remove(sale);
                Save(sales);
            }
            return true;
        }

        public bool Update(Sale sale)
        {
            var sales = GetAll().ToList();
            var index = sales.FindIndex(p => p.Id == sale.Id);
            if (index != -1)
            {
                sales[index] = sale;
                Save(sales);
            }
            return true;
        }

        private void Save(List<Sale> sales)
        {
            var jsonData = JsonSerializer.Serialize(sales, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILE_PATH, jsonData);
        }
    }
}
