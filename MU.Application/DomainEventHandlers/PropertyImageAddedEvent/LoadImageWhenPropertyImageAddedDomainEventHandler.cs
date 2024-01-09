using MediatR;
using Microsoft.Extensions.Logging;
using MU.Application.Services.ImageService;
using MU.Domain.Entities.Events;
using MU.Domain.Entities.Properties;
using MU.Domain.Entities.PropertyImages;
using MU.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.Application.DomainEventHandlers.PropertyImageAddedEvent
{
    public  class LoadImageWhenPropertyImageAddedDomainEventHandler : INotificationHandler<PropertyImageAddedDomainEvent>
    {
        private readonly IImageService _imageService;
        private readonly IRepositoryPropertyImage _repositoryPropertyImage;

        public LoadImageWhenPropertyImageAddedDomainEventHandler(IImageService imageService, IRepositoryPropertyImage repositoryPropertyImage)
        {
            _imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
            _repositoryPropertyImage = repositoryPropertyImage ?? throw new ArgumentNullException(nameof(repositoryPropertyImage));
        }

        public async Task Handle(PropertyImageAddedDomainEvent propertyImageAddedEvent, CancellationToken cancellationToken)
        {
            PropertyImage? propertyImage = await _repositoryPropertyImage.SearchByIdAsync(propertyImageAddedEvent.PropertyImage.IdPropertyImage);
            if (propertyImage is null)
                return;

            if (propertyImageAddedEvent.PropertyImage.PathFolder is null || propertyImageAddedEvent.PropertyImage.FileData is null)
                return;

            string PathFolderForProperty = Path.Combine(propertyImageAddedEvent.PropertyImage.PathFolder, propertyImageAddedEvent.Property.IdProperty.Value.ToString());
            await _imageService.UploadAsync(PathFolderForProperty, propertyImage.File, propertyImageAddedEvent.PropertyImage.FileData);
        }
    }
}
