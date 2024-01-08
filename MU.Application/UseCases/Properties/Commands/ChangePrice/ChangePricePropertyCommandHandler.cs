using ErrorOr;
using MediatR;
using MU.Application.UseCases.Properties.Commands.UpdatePrice;
using MU.Domain.Entities.Properties;
using MU.Domain.Primitives;

namespace MU.Application.UseCases.Properties.Commands.ChangePrice
{
    internal sealed class ChangePricePropertyCommandHandler : IRequestHandler<ChangePricePropertyCommand, ErrorOr<Unit>>
    {
        private readonly IRepositoryProperty _repositoryProperty;
        private readonly IUnitOfWork _unitOfWork;

        public ChangePricePropertyCommandHandler(IRepositoryProperty repositoryProperty, IUnitOfWork unitOfWork)
        {
            _repositoryProperty = repositoryProperty ?? throw new ArgumentNullException(nameof(repositoryProperty));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(ChangePricePropertyCommand request, CancellationToken cancellationToken)
        {
            Property? Property = await _repositoryProperty.SearchByIdAsync(new PropertyId(request.IdProperty));
            if (Property is null)
            {
                return PropertyErrors.propertyNotFound;
            }

            Property.ChangePrice(request.NewPrice);
            _repositoryProperty.Update(Property);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
