using ErrorOr;
using MediatR;
using MU.Domain.Entities;

namespace MU.Application.UseCases.Properties.Queries.List
{
    public record ListPropertiesQuery() : IRequest<ErrorOr<IReadOnlyList<Property>>>;
}
