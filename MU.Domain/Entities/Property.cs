using MU.Domain.Entities.Owners;
using MU.Domain.Primitives;
using MU.Domain.ValueObjects;

namespace MU.Domain.Entities
{
    public class Property : AggregateRoot
    {
        public Property(string name, Address address,
            double priceSale, InternalCodeProperty codeInternal, int yearBuild,
            int idOwner, bool enabled)
        {
            Name = name;
            Address = address;
            PriceSale = priceSale;
            CodeInternal = codeInternal;
            YearBuild = yearBuild;
            IdOwner = idOwner;
            Enabled = enabled;
            PropertyImages = new List<PropertyImage>();
            PropertyTraces = new List<PropertyTrace>();
        }

        private Property() { }

        public int IdProperty { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public Address Address { get; private set; }
        public double PriceSale { get; private set; }
        public InternalCodeProperty CodeInternal { get; private set; }
        public int YearBuild { get; private set; }
        public int IdOwner { get; private set; }
        public bool Enabled { get; private set; }

        public virtual Owner? Owner { get; private set; }
        public virtual ICollection<PropertyImage> PropertyImages { get; private set; }
        public virtual ICollection<PropertyTrace> PropertyTraces { get; private set; }

        public void SetOwner(Owner owner)
        {
            Owner = owner;
        }
        public void AddPropertyImage(PropertyImage propertyImage)
        {
            PropertyImages.Add(propertyImage);
            //Raise(new DomainEvent(Guid.NewGuid()));
        }
        public void AddPropertyTrace(PropertyTrace propertyTrace)
        {
            PropertyTraces.Add(propertyTrace);
        }
    }
}