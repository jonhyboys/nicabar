namespace Domain.Categories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(Guid id);
        bool Add(Category category);
        bool Update(Category category);
        bool Delete(Guid id);
    }
}
