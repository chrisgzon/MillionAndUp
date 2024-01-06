namespace MU.Domain.Entities
{
    public class PropertyTrace
    {
        public int IdPropertyTrace { get; set; }
        public DateTime DateSale { get; set; }
        public string NameClient { get; set; } = string.Empty;
        public int TypeSale { get; set; }
        public double Value { get; set; }
        public decimal Tax { get; set; }
        public int IdProperty { get; set; }

        public virtual Property Property { get; set; } = new Property();
    }
}
