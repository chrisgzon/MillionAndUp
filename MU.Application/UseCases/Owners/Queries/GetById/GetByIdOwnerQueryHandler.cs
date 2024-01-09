using ErrorOr;
using MediatR;
using MU.Application.UseCases.Properties.Queries.SearchPropertyById;
using MU.Domain.Entities.Owners;
using MU.Domain.Entities.Properties;
using MU.Domain.Interfaces.Repositories;

namespace MU.Application.UseCases.Owners.Queries.GetById
{
    internal sealed class GetByIdOwnerQueryHandler : IRequestHandler<GetByIdOwnerQuery, ErrorOr<OwnerResponse>>
    {
        private readonly IRepositoryOwner _repositoryOwner;

        public GetByIdOwnerQueryHandler(IRepositoryOwner repositoryOwner)
        {
            _repositoryOwner = repositoryOwner ?? throw new ArgumentNullException(nameof(repositoryOwner));
        }

        public async Task<ErrorOr<OwnerResponse>> Handle(GetByIdOwnerQuery request, CancellationToken cancellationToken)
        {
            Owner? owner = await _repositoryOwner.SearchByIdAsync(new OwnerId(request.OwnerId));
            if (owner is null)
                return OwnerErrors.OwnerNotFound;

            return new OwnerResponse(
                        owner.IdOwner.Value,
                        owner.Name,
                        owner.Address.AddressString,
                        owner.Photo,
                        owner.Birthay,
                        owner.Enabled,
                        owner._properties.Select(p => new PropertyResponse(
                            p.IdProperty.Value,
                            p.Name,
                            p.YearBuild,
                            p.Address.AddressString,
                            p.CodeInternal.Value,
                            p.Enabled,
                            p.IdOwner.Value,
                            null
                        )).ToList()
                    );
        }
    }
}
