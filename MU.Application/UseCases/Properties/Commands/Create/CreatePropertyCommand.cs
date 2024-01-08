using ErrorOr;
using MediatR;
using MU.Domain.Entities;

namespace MU.Application.UseCases.Properties.Commands.Create
{
    public record CreatePropertyCommand(
        int IdProperty,
        string Name,
        string City,
        string State,
        string Line1,
        string Line2,
        string ZipCode,
        double PriceSale,
        int YearBuild,
        int IdOwner,
        bool Enabled) : IRequest<ErrorOr<Unit>>;
}