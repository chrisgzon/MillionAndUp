using ErrorOr;
using MediatR;
using MU.Domain.Entities;
using MU.Domain.Entities.Properties;
using MU.Domain.ValueObjects;

namespace MU.Application.UseCases.Properties.Commands.Create
{
    internal sealed class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, ErrorOr<Unit>>
    {
        private readonly IRepositoryProperty _repositoryProperty;

        public CreatePropertyCommandHandler(IRepositoryProperty repositoryProperty)
        {
            _repositoryProperty = repositoryProperty ?? throw new ArgumentNullException(nameof(repositoryProperty));
        }

        public async Task<ErrorOr<Unit>> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            if (Address.Create(request.City, request.State, request.Line1, request.Line2, request.ZipCode) is not Address address)
            {
                return Error.Validation("Property.Address", "Address is not valid.");
            }

            if (InternalCodeProperty.Create(request.Name, request.YearBuild) is not InternalCodeProperty internalCode)
            {
                return Error.Validation("Property.CodeInternal", "Not was possible build the code internal of the property, please review the data.");
            }

            Property Property = new Property
            {
                Address = address,
                CodeInternal = internalCode,
                Enabled = request.Enabled,
                IdOwner = request.IdOwner,
                IdProperty = request.IdProperty,
                Name = request.Name,
                PriceSale = request.PriceSale,
                YearBuild = request.YearBuild,
            };

            await _repositoryProperty.Create(Property);
            return Unit.Value;
        }
    }
}