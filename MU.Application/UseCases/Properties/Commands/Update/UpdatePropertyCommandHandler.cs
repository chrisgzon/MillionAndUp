using ErrorOr;
using MediatR;
using MU.Domain.Entities.Properties;
using MU.Domain.Primitives;

namespace MU.Application.UseCases.Properties.Commands.Update
{
    internal sealed class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, ErrorOr<Unit>>
    {
        private readonly IRepositoryProperty _repositoryProperty;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePropertyCommandHandler(IRepositoryProperty repositoryProperty, IUnitOfWork unitOfWork)
        {
            _repositoryProperty = repositoryProperty ?? throw new ArgumentNullException(nameof(repositoryProperty));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            Property? property = await _repositoryProperty.SearchByIdAsync(new PropertyId(request.IdProperty));
            if (property is null)
            {
                return PropertyErrors.propertyNotFound;
            }

            property.Update(request.NameProperty, request.YearBuild);
            _repositoryProperty.Update(property);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}