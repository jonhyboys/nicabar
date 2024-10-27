namespace Domain.Categories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        bool Add(Category category);
    }
}
