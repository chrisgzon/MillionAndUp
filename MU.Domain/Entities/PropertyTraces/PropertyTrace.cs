using MU.Domain.Entities.Properties;
using MU.Domain.Primitives;

namespace MU.Domain.Entities.PropertyTraces
{
    public class PropertyTrace
    {
        public PropertyTrace(PropertyTraceId idPropertyTrace, DateTime date, string nameClient,
            double value, decimal tax, PropertyId idProperty, Property property)
        {
            IdPropertyTrace = idPropertyTrace;
            Date = date;
            NameClient = nameClient;
            Value = value;
            Tax = tax;
            IdProperty = idProperty;
            Property = property;
        }

        private PropertyTrace() { }
        public PropertyTraceId IdPropertyTrace { get; private set; }
        public DateTime Date { get; private set; }
        public string NameClient { get; private set; } = string.Empty;
        public double Value { get; private set; }
        public decimal Tax { get; private set; }
        public PropertyId IdProperty { get; private set; }

        public virtual Property Property { get; private set; }
    }
}
