using Domain.Categories;

namespace Application.Categories
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetById(Guid id);
        bool Add(string name);
        bool Update(Category category);
        bool Delete(Guid id);
    }
}
