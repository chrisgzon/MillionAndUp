using ErrorOr;
using MediatR;
using MU.Domain.Entities.Properties;

namespace MU.Application.UseCases.Properties.Queries.List
{
    public record ListPropertiesQuery() : IRequest<ErrorOr<IReadOnlyList<Property>>>;
}
