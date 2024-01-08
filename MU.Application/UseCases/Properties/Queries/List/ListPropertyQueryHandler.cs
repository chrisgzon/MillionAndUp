using MediatR;
using MU.Domain.Entities;
using MU.Domain.Entities.Properties;

namespace MU.Application.UseCases.Properties.Queries.List
{
    internal sealed class ListPropertiesQueryHandler : IRequestHandler<ListPropertiesQuery, ICollection<Property>>
    {
        private readonly IRepositoryProperty _repositoryProperty;

        public ListPropertiesQueryHandler(IRepositoryProperty repositoryProperty)
        {
            _repositoryProperty = repositoryProperty ?? throw new ArgumentNullException(nameof(repositoryProperty));
        }

        public async Task<ICollection<Property>> Handle(ListPropertiesQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryProperty.ListAsync();
        }
    }
}