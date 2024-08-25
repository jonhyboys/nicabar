using Domain.Tables;

namespace Application.Tables
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public IEnumerable<Table> GetAll()
        {
            return _tableRepository.GetAll();
        }

        public Table GetById(Guid id)
        {
            return _tableRepository.GetById(id);
        }

        public bool Add(TableAddModel tableAddModel)
        {
            Table table = new Table() { 
                Id = Guid.NewGuid(),
                Name = tableAddModel.Name,
                Capacity = tableAddModel.Capacity,
                Configuration = tableAddModel.Configuration,
                Start = DateTime.Now,
                End = null
            };
            return _tableRepository.Add(table);
        }
    }
}
