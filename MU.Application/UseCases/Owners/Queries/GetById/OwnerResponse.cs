using MU.Application.UseCases.Properties.Queries.SearchPropertyById;

namespace MU.Application.UseCases.Owners.Queries.GetById
{
    public class OwnerResponse
    {
        public OwnerResponse(Guid idOwner, string name, string address, string photo, DateTime birthay, bool enabled, List<PropertyResponse> properties)
        {
            IdOwner = idOwner;
            Name = name;
            Address = address;
            Photo = photo;
            Birthay = birthay;
            Enabled = enabled;
            Properties = properties;
        }

        public Guid IdOwner { get; }
        public string Name { get; }
        public string Address { get; }
        public string Photo { get; }
        public DateTime Birthay { get; }
        public bool Enabled { get; }

        public List<PropertyResponse> Properties { get; }
    }
}
