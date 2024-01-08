using ErrorOr;
using MediatR;

namespace MU.Application.UseCases.Properties.Commands.ChangeAddress
{
    public record ChangeAddressPropertyCommand(
        Guid IdProperty,
        string City,
        string State,
        string Line1,
        string Line2,
        string ZipCode) : IRequest<ErrorOr<Unit>>;
}
