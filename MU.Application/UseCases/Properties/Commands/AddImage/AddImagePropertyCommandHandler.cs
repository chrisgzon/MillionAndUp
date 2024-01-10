using ErrorOr;
using MediatR;
using MU.Domain.Entities.Properties;
using MU.Domain.Entities.PropertyImages;
using MU.Domain.Primitives;
using System.Text.RegularExpressions;

namespace MU.Application.UseCases.Properties.Commands.AddImage
{
    public sealed class AddImagePropertyCommandHandler : IRequestHandler<AddImagePropertyCommand, ErrorOr<Guid>>
    {
        private readonly IRepositoryProperty _repositoryProperty;
        private readonly IUnitOfWork _unitOfWork;
        private const string Pattern = "[^\\s]+(.*?)\\.(jpg|jpeg|png|JPG|JPEG|PNG)$";
        private const int FileLengthMaxKb = 50;

        public AddImagePropertyCommandHandler(IRepositoryProperty repositoryProperty, IUnitOfWork unitOfWork)
        {
            _repositoryProperty = repositoryProperty ?? throw new ArgumentNullException(nameof(repositoryProperty));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Guid>> Handle(AddImagePropertyCommand request, CancellationToken cancellationToken)
        {
            Regex Regex = new Regex(Pattern, RegexOptions.Compiled);
            if (!Regex.IsMatch(request.FileName))
            {
                return PropertyImageErrors.ExtentionFileInvalid;
            }
            if (request.FileLengt / 1024 > FileLengthMaxKb)
            {
                return PropertyImageErrors.SizeFileInvalid;
            }
            if (string.IsNullOrWhiteSpace(request.PathFolder))
            {
                return PropertyImageErrors.PathDirectoryNotGetted;
            }

            Property? Property = await _repositoryProperty.SearchByIdAsync(new PropertyId(request.IdProperty));
            if (Property == null) {
                return PropertyImageErrors.PropertyNotFound;
            }

            Guid propertyImageId = Guid.NewGuid();
            string fileNameCustom = string.Format("{0}{1}", DateTime.Now.Ticks.ToString(), Path.GetExtension(request.FileName));
            string PathFile = Path.Combine(request.PathFolder, Property.IdProperty.Value.ToString(), fileNameCustom);
            PropertyImage propertyImage = new PropertyImage(
                new PropertyImageId(propertyImageId),
                Property.IdProperty,
                PathFile,
                true,
                request.PathFolder,
                request.BytesFile,
                request.FileLengt);
            Property.AddPropertyImage(propertyImage);
            _repositoryProperty.Update(Property);
            await _unitOfWork.SaveChangesAsync();

            return propertyImage.IdPropertyImage.Value;
        }
    }
}
