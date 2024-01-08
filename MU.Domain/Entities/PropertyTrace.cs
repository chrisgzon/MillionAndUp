namespace MU.Domain.Entities
{
    public class PropertyTrace
    {
        public PropertyTrace(int idPropertyTrace, DateTime date, string nameClient,
            double value, decimal tax, int idProperty, Property property)
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
        public int IdPropertyTrace { get; private set; }
        public DateTime Date { get; private set; }
        public string NameClient { get; private set; } = string.Empty;
        public double Value { get; private set; }
        public decimal Tax { get; private set; }
        public int IdProperty { get; private set; }

        public virtual Property Property { get; private set; }
    }
}
