using MU.Domain.Entities.Owners;
using MU.Domain.ValueObjects;

namespace MU.Domain.Entities
{
    public class Property
    {
        public int IdProperty { get; set; }
        public string Name { get; set; } = string.Empty;
        public Address? Address { get; set; }
        public double PriceSale { get; set; }
        public InternalCodeProperty? CodeInternal { get; set; }
        public int YearBuild { get; set; }
        public int IdOwner { get; set; }
        public bool Enabled { get; set; }

        public virtual Owner? Owner { get; set; }
        public virtual ICollection<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();
        public virtual ICollection<PropertyTrace> PropertyTraces { get; set; } = new List<PropertyTrace>();
    }
}