using ErrorOr;
using MediatR;

namespace MU.Application.UseCases.Tokens.Queries.GenerateToken
{
    public record class GenerateTokenQuery(Guid IdOwner) : IRequest<ErrorOr<GenerateTokenResult>>;
}
