using ErrorOr;
using MediatR;

namespace MU.Application.UseCases.Tokens.Queries
{
    public record class GenerateTokenQuery(Guid IdOwner) : IRequest<ErrorOr<GenerateTokenResult>>;
}
