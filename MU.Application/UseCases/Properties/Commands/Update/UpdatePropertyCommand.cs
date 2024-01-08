using ErrorOr;
using MediatR;

namespace MU.Application.UseCases.Properties.Commands.Update
{
    public record class UpdatePropertyCommand(
        Guid IdProperty,
        string NameProperty,
        int YearBuild) : IRequest<ErrorOr<Unit>>;
}