using MU.Domain.Primitives;
using MU.Domain.ValueObjects;
using MU.Domain.Entities.Properties;
using MediatR;

namespace MU.Domain.Entities.Owners
{
    public class Owner : AggregateRoot
    {
        public Owner(OwnerId idOwner, string name, Address address, string photo, DateTime birthay, bool enabled)
        {
            IdOwner = idOwner;
            Name = name;
            Address = address;
            Photo = photo;
            Birthay = birthay;
            Enabled = enabled;
        }

        private Owner() {}

        public OwnerId IdOwner { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public Address Address { get; private set; }
        public string Photo { get; private set; } = string.Empty; // set path complete of file
        public DateTime Birthay { get; private set; }
        public bool Enabled { get; private set; }

        public ICollection<Property> _properties { get; private set; } = new List<Property>();

        public void AddPropertie(Property property)
        {
            var existingPropertieInOwner = _properties.Where(p => p.IdProperty == property.IdProperty || p.Address == property.Address || p.CodeInternal == property.CodeInternal)
                .FirstOrDefault();

            if (existingPropertieInOwner is null)
            {
                _properties.Add(property);
                //TODO: add domain event
            }
        }
    }
}