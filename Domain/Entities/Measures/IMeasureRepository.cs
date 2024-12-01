namespace Domain.Measures
{
    public interface IMeasureRepository
    {
        bool Add(Measure measure);
        IEnumerable<Measure> GetAll();
    }
}
