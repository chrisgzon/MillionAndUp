using ErrorOr;
using MediatR;

namespace MU.Application.UseCases.Properties.Queries.SearchPropertyById
{
    public record SearchPropertyByIdQuery(Guid propertyId) : IRequest<ErrorOr<PropertyResponse>>;
}
