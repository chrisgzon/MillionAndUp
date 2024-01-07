using MediatR;
using MU.Domain.Entities.Owners;
using MU.Domain.Entities.Properties;
using MU.Domain.Primitives;
using MU.Domain.ValueObjects;

namespace MU.Application.UseCases.Properties.Commands.Create
{
    internal sealed class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, Unit>
    {
        private readonly IRepositoryProperty _repositoryProperty;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePropertyCommandHandler(IRepositoryProperty repositoryProperty, IUnitOfWork unitOfWork)
        {
            _repositoryProperty = repositoryProperty ?? throw new ArgumentNullException(nameof(repositoryProperty));
            _unitOfWork = _unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            if (Address.Create(request.City, request.State, request.Line1, request.Line2, request.ZipCode) is not Address address)
            {
                throw new ArgumentException(nameof(address));
            }

            if (InternalCodeProperty.Create(request.Name, request.YearBuild) is not InternalCodeProperty internalCode)
            {
                throw new ArgumentException(nameof(internalCode));
            }

            Property Property = new Property(
                new PropertyId(0),
                request.Name,
                address,
                request.PriceSale,
                internalCode,
                request.YearBuild,
                new OwnerId(request.IdOwner),
                request.Enabled);

            await _repositoryProperty.Create(Property);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}