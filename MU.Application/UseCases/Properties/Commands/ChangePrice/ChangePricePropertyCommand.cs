using ErrorOr;
using MediatR;

namespace MU.Application.UseCases.Properties.Commands.UpdatePrice
{
    public record ChangePricePropertyCommand(Guid IdProperty, double NewPrice) : IRequest<ErrorOr<Unit>>;
}
