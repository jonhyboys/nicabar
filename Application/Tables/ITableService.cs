using Domain.Tables;

namespace Application.Tables
{
    public interface ITableService
    {
        IEnumerable<Table> GetAll();
        Table GetById(Guid id);
        bool Add(TableAddModel tableAddModel);
    }
}
