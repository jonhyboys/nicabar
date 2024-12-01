using Domain.Measures;

namespace Application.Measures
{
    public interface IMeasureService
    {
        bool Add(string name);
        IEnumerable<Measure> GetAll();
    }
}
