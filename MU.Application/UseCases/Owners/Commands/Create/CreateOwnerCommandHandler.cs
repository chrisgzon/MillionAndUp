using ErrorOr;
using MediatR;
using MU.Domain.Entities.Owners;
using MU.Domain.Interfaces.Repositories;
using MU.Domain.Primitives;
using MU.Domain.ValueObjects;

namespace MU.Application.UseCases.Owners.Commands.Create
{
    internal class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, ErrorOr<Guid>>
    {
        private readonly IRepositoryOwner _repositoryOwner;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOwnerCommandHandler(IRepositoryOwner repositoryOwner, IUnitOfWork unitOfWork)
        {
            _repositoryOwner = repositoryOwner ?? throw new ArgumentException(nameof(repositoryOwner));
            _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Guid>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            if (Address.Create(request.City, request.State, request.Line1, request.Line2, request.ZipCode) is not Address address)
            {
                return OwnerErrors.AddressWithBadFormat;
            }

            if (request.Birthay > DateTime.Now)
            {
                return OwnerErrors.BirthayNotValid;
            }

            Owner owner = new Owner(
                new OwnerId(Guid.NewGuid()),
                request.Name,
                address,
                string.Empty,
                request.Birthay,
                request.Enabled
            );

            await _repositoryOwner.CreateAsync(owner);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return owner.IdOwner.Value;
        }
    }
}
