using Domain.Measures;

namespace Application.Measures
{
    public class MeasureService: IMeasureService
    {
        private readonly IMeasureRepository _measureRepository;

        public MeasureService(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
        }

        public IEnumerable<Measure> GetAll()
        {
            IEnumerable<Measure> measures = _measureRepository.GetAll();
            if (measures.Any()) { return measures; }
            SetLocalMeasures();
            return _measureRepository.GetAll();
        }

        public bool Add(string name)
        {
            Measure measure = new Measure()
            {
                Id = Guid.NewGuid(),
                Name = name
            };
            return _measureRepository.Add(measure);
        }

        private void SetLocalMeasures()
        {
            Add("Litro");
            Add("Ración");
            Add("Docena");
            Add("Unidad");
        }
    }
}
