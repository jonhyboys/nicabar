using Application.Products;
using Domain.Categories;

namespace Application.Categories
{
    internal class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductService _productService;

        public CategoryService(ICategoryRepository categoryRepository, IProductService productService)
        {
            _categoryRepository = categoryRepository;
            _productService = productService;
        }

        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAll();
            if (categories.Any()) { return categories; }
            SetLocalCategories();
            return _categoryRepository.GetAll();
        }

        public Category GetById(Guid id)
        {
            return _categoryRepository.GetById(id);
        }

        public IEnumerable<Category> GetInUse()
        {
            IEnumerable<Guid> products = _productService.GetAll().Select(p => p.Category).Distinct();
            return GetAll().Where(c => products.Contains(c.Id));
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
            return _categoryRepository.Update(category);
        }

        public bool Delete(Guid id)
        {
            return _categoryRepository.Delete(id);
        }

        private void SetLocalCategories()
        {
            Add("Bebidas");
            Add("Bebidas alcohólicas");
            Add("Comida");
            Add("Otros");
        }
    }
}