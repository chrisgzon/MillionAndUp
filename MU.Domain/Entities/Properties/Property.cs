using MU.Domain.Entities.Owners;
using MU.Domain.Entities.PropertyImages;
using MU.Domain.Entities.PropertyTraces;
using MU.Domain.Primitives;
using MU.Domain.ValueObjects;

namespace MU.Domain.Entities.Properties
{
    public class Property : AggregateRoot
    {
        public Property(PropertyId idProperty, string name, Address address,
            double priceSale, InternalCodeProperty codeInternal, int yearBuild,
            OwnerId idOwner, bool enabled)
        {
            IdProperty = idProperty;
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

        public PropertyId IdProperty { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public Address Address { get; private set; }
        public double PriceSale { get; private set; }
        public InternalCodeProperty CodeInternal { get; private set; }
        public int YearBuild { get; private set; }
        public OwnerId IdOwner { get; private set; }
        public bool Enabled { get; private set; }

        public Owner? Owner { get; private set; }
        public ICollection<PropertyImage> PropertyImages { get; private set; }
        public ICollection<PropertyTrace> PropertyTraces { get; private set; }

        public void SetOwner(Owner owner)
        {
            Owner = owner;
        }
        public void AddPropertyImage(PropertyImage propertyImage)
        {
            PropertyImages.Add(propertyImage);
        }
        public void AddPropertyTrace(PropertyTrace propertyTrace)
        {
            PropertyTraces.Add(propertyTrace);
        }

        public void ChangePrice(double newPrice)
        {
            if (PriceSale != newPrice)
            {
                PriceSale = newPrice;
                //TODO: Add domain event
            }
        }
    }
}