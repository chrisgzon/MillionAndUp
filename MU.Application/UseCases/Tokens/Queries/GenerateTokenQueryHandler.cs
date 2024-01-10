using ErrorOr;
using MediatR;
using MU.Application.Services.JWTGenerator;
using MU.Domain.Entities.Owners;
using MU.Domain.Interfaces.Repositories;

namespace MU.Application.UseCases.Tokens.Queries
{
    internal sealed class GenerateTokenQueryHandler : IRequestHandler<GenerateTokenQuery, ErrorOr<GenerateTokenResult>>
    {
        private readonly IRepositoryOwner _repositoryOwner;
        private readonly IJWTGenerator _jwtGenerator;

        public GenerateTokenQueryHandler(IRepositoryOwner repositoryOwner, IJWTGenerator jwtGenerator)
        {
            _repositoryOwner = repositoryOwner ?? throw new ArgumentNullException(nameof(repositoryOwner));
            _jwtGenerator = jwtGenerator ?? throw new ArgumentNullException(nameof(jwtGenerator));
        }

        public async Task<ErrorOr<GenerateTokenResult>> Handle(GenerateTokenQuery request, CancellationToken cancellationToken)
        {
            Owner? owner = await _repositoryOwner.SearchByIdAsync(new OwnerId(request.IdOwner));
            if (owner is null)
                return OwnerErrors.OwnerNotFound;

            string token = _jwtGenerator.GenerateToken(
                owner.IdOwner.Value,
                owner.Name,
                owner.Address.AddressString,
                owner.Birthay);

            GenerateTokenResult authResult = new GenerateTokenResult(
                owner.IdOwner.Value,
                owner.Name,
                owner.Address.AddressString,
                owner.Birthay,
                token);

            return ErrorOrFactory.From(authResult);
        }
    }
}
