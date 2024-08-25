using Domain.Tables;
using System.Text.Json;

namespace Infrastructure.Tables
{
    public class TableRepository : ITableRepository
    {
        const string FILE_PATH = "Tables.json";

        public Table GetById(Guid id)
        {
            var tables = GetAll().ToList();
            return tables.Find(p => p.Id == id);
        }

        public IEnumerable<Table> GetAll()
        {
            if (File.Exists(FILE_PATH))
            {
                var jsonData = File.ReadAllText(FILE_PATH);
                return JsonSerializer.Deserialize<List<Table>>(jsonData);
            }
            return [];
        }

        public bool Add(Table table)
        {
            var tables = GetAll().ToList();
            tables.Add(table);
            Save(tables);
            return true;
        }

        public bool Delete(Guid id)
        {
            var tables = GetAll().ToList();
            var table = tables.Find(p => p.Id == id);
            if (table != null)
            {
                tables.Remove(table);
                Save(tables);
            }
            return true;
        }

        public bool Update(Table table)
        {
            var tables = GetAll().ToList();
            var index = tables.FindIndex(p => p.Id == table.Id);
            if (index != -1)
            {
                tables[index] = table;
                Save(tables);
            }
            return true;
        }

        private void Save(List<Table> tables)
        {
            var jsonData = JsonSerializer.Serialize(tables, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILE_PATH, jsonData);
        }
    }
}
