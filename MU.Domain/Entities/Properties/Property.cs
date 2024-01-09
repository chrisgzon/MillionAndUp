using MediatR;
using MU.Domain.Entities.Events;
using MU.Domain.Entities.Owners;
using MU.Domain.Entities.PropertyImages;
using MU.Domain.Entities.PropertyTraces;
using MU.Domain.Primitives;
using MU.Domain.ValueObjects;
using System.Text.RegularExpressions;

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
        public ICollection<PropertyImage> PropertyImages { get; private set; } = new List<PropertyImage>();
        public ICollection<PropertyTrace> PropertyTraces { get; private set; } = new List<PropertyTrace>();

        public void SetOwner(Owner owner)
        {
            Owner = owner;
        }

        public void AddPropertyImage(PropertyImage propertyImage)
        {
            string Pattern = "[^\\s]+(.*?)\\.(jpg|jpeg|png|JPG|JPEG|PNG)$";
            int FileLengthMaxKb = 50;
            Regex Regex = new Regex(Pattern, RegexOptions.Compiled);
            if (string.IsNullOrWhiteSpace(propertyImage.File) || !Regex.IsMatch(propertyImage.File))
                return;

            if (propertyImage.FileLength / 1024 > FileLengthMaxKb)
                return;

            PropertyImages.Add(propertyImage);

            // Add the PropertyImageAddedDomainEvent to the domain events collection 
            // to be raised/dispatched when comitting changes into the Database [ After DbContext.SaveChanges() ]
            AddImageAddedDomainEvent(propertyImage);
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

        public void Update(string nameProperty, int year)
        {
            if (Name == nameProperty && year == YearBuild)
                return;

            Name = nameProperty;
            YearBuild = year;
            //TODO: Add domain event
        }

        public void ChangeAddress(Address newAddress)
        {
            if (Address != newAddress)
            {
                Address = newAddress;
                //TODO: Add domain event
            }
        }

        private void AddImageAddedDomainEvent(PropertyImage propertyImage)
        {
            PropertyImageAddedDomainEvent PropertyImageAddedDomainEvent = new PropertyImageAddedDomainEvent(this, propertyImage);

            Raise(PropertyImageAddedDomainEvent);
        }
    }
}