using MU.Domain.Entities.Properties;

namespace MU.Domain.Entities.PropertyTraces
{
    public class PropertyTrace
    {
        public PropertyTraceId IdPropertyTrace { get; set; }
        public DateTime Date { get; set; }
        public string NameClient { get; set; } = string.Empty;
        public double Value { get; set; }
        public decimal Tax { get; set; }
        public PropertyId IdProperty { get; set; }

        public virtual Property? Property { get; set; }
    }
}
