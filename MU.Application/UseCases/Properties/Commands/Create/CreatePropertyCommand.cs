using ErrorOr;
using MediatR;

namespace MU.Application.UseCases.Properties.Commands.Create
{
    public record CreatePropertyCommand(
        string Name,
        string City,
        string State,
        string Line1,
        string Line2,
        string ZipCode,
        double PriceSale,
        int YearBuild,
        Guid IdOwner,
        bool Enabled) : IRequest<ErrorOr<Unit>>;
}