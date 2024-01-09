using ErrorOr;
using MediatR;

namespace MU.Application.UseCases.Owners.Commands.Create
{
    public record class CreateOwnerCommand(
        string Name,
        string City,
        string State,
        string Line1,
        string Line2,
        string ZipCode,
        bool Enabled,
        DateTime Birthay) : IRequest<ErrorOr<Guid>>;
}
