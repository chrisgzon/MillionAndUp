using MediatR;
using MU.Domain.Entities;

namespace MU.Application.UseCases.Properties.Queries.List
{
    public record ListPropertiesQuery() : IRequest<ICollection<Property>>;
}
