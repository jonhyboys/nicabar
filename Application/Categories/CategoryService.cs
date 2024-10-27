using Domain.Categories;

namespace Application.Categories
{
    internal class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAll()
        {
            return GetLocalCategories(); //_categoryRepository.GetAll();
        }

        public Category GetById(Guid id)
        {
            return null;// _categoryRepository.GetById(id);
        }

        public bool Add(string name)
        {
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = name
            };
            return _categoryRepository.Add(category);
        }

        public bool Update(Category category)
        {
            return true;// _categoryRepository.Update(category);
        }

        public bool Delete(Guid id)
        {
            return true; // _categoryRepository.Delete(id);
        }

        private IEnumerable<Category> GetLocalCategories()
        {
            return new List<Category>() {
                new Category() {
                    Id = new Guid(),
                    Name = "Bebidas"
                },
                new Category() {
                    Id = new Guid(),
                    Name = "Bebidas alcohólicas"
                },
                new Category() {
                    Id = new Guid(),
                    Name = "Comida"
                }
            };
        }
    }
}
