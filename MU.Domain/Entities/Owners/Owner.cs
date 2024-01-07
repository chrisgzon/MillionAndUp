using MU.Domain.Primitives;
using MU.Domain.ValueObjects;
using MU.Domain.Entities.Properties;

namespace MU.Domain.Entities.Owners
{
    public class Owner
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
        public string Photo { get; private set; } = string.Empty;
        public DateTime Birthay { get; private set; }
        public bool Enabled { get; private set; }

        public virtual ICollection<Property> Properties { get; private set; } = new List<Property>();

        public void SetProperties(List<Property> properties)
        {
            Properties = properties;
        }
    }
}