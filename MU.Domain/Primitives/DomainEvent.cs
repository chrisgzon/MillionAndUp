using MediatR;

namespace MU.Domain.Primitives;

public record DomainEvent(Guid Id) : INotification;
