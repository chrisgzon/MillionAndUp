using ErrorOr;
using MediatR;
using MU.Application.UseCases.Properties.Queries.SearchPropertyById;
using MU.Domain.Entities.Properties;

namespace MU.Application.UseCases.Properties.Queries.List
{
    internal sealed class ListPropertiesQueryHandler : IRequestHandler<ListPropertiesQuery, ErrorOr<IReadOnlyList<PropertyResponse>>>
    {
        private readonly IRepositoryProperty _repositoryProperty;

        public ListPropertiesQueryHandler(IRepositoryProperty repositoryProperty)
        {
            _repositoryProperty = repositoryProperty ?? throw new ArgumentNullException(nameof(repositoryProperty));
        }

        public async Task<ErrorOr<IReadOnlyList<PropertyResponse>>> Handle(ListPropertiesQuery request, CancellationToken cancellationToken)
        {
            List<Property> Properties = await _repositoryProperty.ListAsync();

            return Properties.Select(p => new PropertyResponse(
                p.IdProperty.Value,
                p.Name,
                p.YearBuild,
                p.Address.AddressString,
                p.CodeInternal.Value,
                p.IdOwner.Value
            )).ToList();
        }
    }
}