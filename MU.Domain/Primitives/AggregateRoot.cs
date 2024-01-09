using MediatR;

namespace MU.Domain.Primitives
{
    public abstract class AggregateRoot
    {
        private readonly List<INotification> _domainEvents = new();

        public ICollection<INotification> GetDomainEvents() => _domainEvents;

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void Raise(INotification domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}