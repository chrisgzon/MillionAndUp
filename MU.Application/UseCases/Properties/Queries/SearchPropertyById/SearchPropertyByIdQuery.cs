using ErrorOr;
using MediatR;
using MU.Domain.Entities.Properties;

namespace MU.Application.UseCases.Properties.Queries.SearchPropertyById
{
    public record SearchPropertyByIdQuery(Guid propertyId) : IRequest<ErrorOr<Property>>;
}
