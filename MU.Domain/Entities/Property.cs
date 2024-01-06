namespace MU.Domain.Entities
{
    public class Property
    {
        public int IdProperty { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Price { get; set; }
        public string CodeInternal { get; set; } = string.Empty;
        public int Year { get; set; }
        public int IdOwner { get; set; }
        public int Enabled { get; set; }

        public virtual Owner Owner { get; set; } = new Owner();
        public virtual ICollection<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();
        public virtual ICollection<PropertyTrace> PropertyTraces { get; set; } = new List<PropertyTrace>();
    }
}