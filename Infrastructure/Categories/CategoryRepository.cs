using Domain.Categories;
using System.Text.Json;

namespace Infrastructure.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        const string FILE_PATH = "Categories.json";

        public Category GetById(Guid id)
        {
            var categories = GetAll().ToList();
            return categories.Find(p => p.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            if (File.Exists(FILE_PATH))
            {
                var jsonData = File.ReadAllText(FILE_PATH);
                return JsonSerializer.Deserialize<List<Category>>(jsonData);
            }
            return [];
        }

        public bool Add(Category category)
        {
            var categories = GetAll().ToList();
            categories.Add(category);
            Save(categories);
            return true;
        }

        public bool Delete(Guid id)
        {
            var categories = GetAll().ToList();
            var category = categories.Find(p => p.Id == id);
            if (category != null)
            {
                categories.Remove(category);
                Save(categories);
            }
            return true;
        }

        public bool Update(Category category)
        {
            var categories = GetAll().ToList();
            var index = categories.FindIndex(p => p.Id == category.Id);
            if (index != -1)
            {
                categories[index] = category;
                Save(categories);
            }
            return true;
        }

        private void Save(List<Category> categories)
        {
            var jsonData = JsonSerializer.Serialize(categories, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILE_PATH, jsonData);
        }
    }
}
