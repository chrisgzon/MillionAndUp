using ErrorOr;
using MediatR;
using MU.Domain.Entities;
using MU.Domain.Entities.Owners;
using MU.Domain.Entities.Properties;
using MU.Domain.Interfaces.Repositories;
using MU.Domain.Primitives;
using MU.Domain.ValueObjects;

namespace MU.Application.UseCases.Properties.Commands.Create
{
    public sealed class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, ErrorOr<Guid>>
    {
        private readonly IRepositoryOwner _ownerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePropertyCommandHandler(IRepositoryOwner ownerRepository, IUnitOfWork unitOfWork)
        {
            _ownerRepository = ownerRepository ?? throw new ArgumentNullException(nameof(ownerRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Guid>> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            if (Address.Create(request.City, request.State, request.Line1, request.Line2, request.ZipCode) is not Address address)
            {
                return PropertyErrors.AddressWithBadFormat;
            }

            if (request.YearBuild > DateTime.Now.Year)
            {
                return PropertyErrors.YearMaxIsCurrent;
            }

            if (InternalCodeProperty.Create(request.Name, request.YearBuild) is not InternalCodeProperty internalCode)
            {
                return PropertyErrors.cannotCreateCodeInternal;
            }

            Owner? owner = await _ownerRepository.SearchByIdAsync(new OwnerId(request.IdOwner));
            if (owner is null)
            {
                return PropertyErrors.ownerNotFound;
            }

            Property Property = new Property(
                new PropertyId(Guid.NewGuid()),
                request.Name,
                address,
                request.PriceSale,
                internalCode,
                request.YearBuild,
                new OwnerId(request.IdOwner),
                request.Enabled);

            owner.AddPropertie(Property);
            _ownerRepository.Update(owner);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Property.IdProperty.Value;
        }
    }
}