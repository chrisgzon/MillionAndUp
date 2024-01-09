using ErrorOr;
using MediatR;
using MU.Application.UseCases.Owners.Queries.GetById;
using MU.Application.UseCases.Properties.Queries.SearchPropertyById;
using MU.Domain.Entities.Owners;
using MU.Domain.Interfaces.Repositories;
using MU.Domain.Primitives;

namespace MU.Application.UseCases.Owners.Queries.GetAll
{
    internal sealed class GetAllOwnersQueryHandler : IRequestHandler<GetAllOwnersQuery, ErrorOr<List<OwnerResponse>>>
    {
        private readonly IRepositoryOwner _repositoryOwner;

        public GetAllOwnersQueryHandler(IRepositoryOwner repositoryOwner, IUnitOfWork unitOfWork)
        {
            _repositoryOwner = repositoryOwner ?? throw new ArgumentNullException(nameof(repositoryOwner));
        }

        public async Task<ErrorOr<List<OwnerResponse>>> Handle(GetAllOwnersQuery request, CancellationToken cancellationToken)
        {
            List<Owner> owners = await _repositoryOwner.ListAsync();
            return owners.Select(o => new OwnerResponse(
                    o.IdOwner.Value,
                    o.Name,
                    o.Address.AddressString,
                    o.Photo,
                    o.Birthay,
                    o.Enabled,
                    o._properties.Select(p => new PropertyResponse(
                        p.IdProperty.Value,
                        p.Name,
                        p.YearBuild,
                        p.Address.AddressString,
                        p.CodeInternal.Value,
                        p.Enabled,
                        p.IdOwner.Value,
                        null
                    )).ToList()
                )).ToList();
        }
    }
}
