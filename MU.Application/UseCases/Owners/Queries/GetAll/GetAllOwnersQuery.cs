using ErrorOr;
using MediatR;
using MU.Application.UseCases.Owners.Queries.GetById;

namespace MU.Application.UseCases.Owners.Queries.GetAll
{
    public record GetAllOwnersQuery : IRequest<ErrorOr<List<OwnerResponse>>>;
}
