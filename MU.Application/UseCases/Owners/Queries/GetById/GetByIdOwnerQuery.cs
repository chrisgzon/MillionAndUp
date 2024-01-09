using ErrorOr;
using MediatR;

namespace MU.Application.UseCases.Owners.Queries.GetById
{
    public record GetByIdOwnerQuery(Guid OwnerId) : IRequest<ErrorOr<OwnerResponse>>;
}
