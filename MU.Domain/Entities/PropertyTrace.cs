namespace MU.Domain.Entities
{
    public class PropertyTrace
    {
        public int IdPropertyTrace { get; set; }
        public DateTime Date { get; set; }
        public string NameClient { get; set; } = string.Empty;
        public double Value { get; set; }
        public decimal Tax { get; set; }
        public int IdProperty { get; set; }

        public virtual Property? Property { get; set; }
    }
}
