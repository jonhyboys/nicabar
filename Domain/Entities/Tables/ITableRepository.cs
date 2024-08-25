namespace Domain.Tables
{
    public interface ITableRepository
    {
        IEnumerable<Table> GetAll();
        Table GetById(Guid id);
        bool Add(Table table);
    }
}
