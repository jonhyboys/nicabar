namespace Domain.Tables
{
    public class Table
    {
        public Guid Id { get; set; }
        public int Name { get; set; }
        public int Capacity { get; set; }
        public int Configuration { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}
