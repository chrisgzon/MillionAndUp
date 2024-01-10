using ErrorOr;
using MediatR;
using MU.Domain.Entities.Properties;
using MU.Domain.Primitives;
using MU.Domain.ValueObjects;

namespace MU.Application.UseCases.Properties.Commands.ChangeAddress
{
    public sealed class ChangeAddressPropertyCommandHandler : IRequestHandler<ChangeAddressPropertyCommand, ErrorOr<Unit>>
    {
        private readonly IRepositoryProperty _repositoryProperty;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeAddressPropertyCommandHandler(IRepositoryProperty repositoryProperty, IUnitOfWork unitOfWork)
        {
            _repositoryProperty = repositoryProperty ?? throw new ArgumentNullException(nameof(repositoryProperty));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(repositoryProperty));
        }

        public async Task<ErrorOr<Unit>> Handle(ChangeAddressPropertyCommand request, CancellationToken cancellationToken)
        {
            Property? property = await _repositoryProperty.SearchByIdAsync(new PropertyId(request.IdProperty));
            if (property is null)
            {
                return PropertyErrors.propertyNotFound;
            }

            if (Address.Create(request.City, request.State, request.Line1, request.Line2, request.ZipCode) is not Address address) 
            {
                return PropertyErrors.AddressWithBadFormat;
            }

            property.ChangeAddress(address);
            _repositoryProperty.Update(property);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
