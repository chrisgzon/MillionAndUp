using ErrorOr;
using MediatR;

namespace MU.Application.UseCases.Properties.Commands.AddImage
{
    public record AddImagePropertyCommand(
        Guid IdProperty,
        string PathFolder,
        byte[] BytesFile,
        string FileName,
        long FileLengt) : IRequest<ErrorOr<Guid>>;
}
