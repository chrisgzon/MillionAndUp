using MediatR;
using MU.Domain.Entities;

namespace MU.Domain.DomainEvents
{
    public class PropertyImageDeletedDomainEvent : INotification
    {
        public Property property {  get; }
        public PropertyImageDeletedDomainEvent(Property _property)
        {
            property = _property;
        }
    }
}