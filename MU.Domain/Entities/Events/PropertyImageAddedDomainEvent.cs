using MediatR;
using MU.Domain.Entities.Properties;
using MU.Domain.Entities.PropertyImages;

namespace MU.Domain.Entities.Events
{
    /// <summary>
    /// Event used when an image is added to property
    /// </summary>
    public class PropertyImageAddedDomainEvent : INotification
    {
        public PropertyImage PropertyImage { get; }
        public Property Property { get; }

        public PropertyImageAddedDomainEvent(Property property, PropertyImage propertyImage)
        {
            Property = property;
            PropertyImage = propertyImage;
        }
    }
}
