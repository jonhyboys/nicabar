using Domain.Measures;
using System.Text.Json;

namespace Infrastructure.Measures
{
    public class MeasureRepository: IMeasureRepository
    {
        const string FILE_PATH = "Measures.json";

        public Measure GetById(Guid id)
        {
            var measures = GetAll().ToList();
            return measures.Find(p => p.Id == id);
        }

        public IEnumerable<Measure> GetAll()
        {
            if (File.Exists(FILE_PATH))
            {
                var jsonData = File.ReadAllText(FILE_PATH);
                return JsonSerializer.Deserialize<List<Measure>>(jsonData);
            }
            return [];
        }

        public bool Add(Measure category)
        {
            var measures = GetAll().ToList();
            measures.Add(category);
            Save(measures);
            return true;
        }

        public bool Delete(Guid id)
        {
            var measures = GetAll().ToList();
            var category = measures.Find(p => p.Id == id);
            if (category != null)
            {
                measures.Remove(category);
                Save(measures);
            }
            return true;
        }

        public bool Update(Measure category)
        {
            var measures = GetAll().ToList();
            var index = measures.FindIndex(p => p.Id == category.Id);
            if (index != -1)
            {
                measures[index] = category;
                Save(measures);
            }
            return true;
        }

        private void Save(List<Measure> measures)
        {
            var jsonData = JsonSerializer.Serialize(measures, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILE_PATH, jsonData);
        }
    }
}
