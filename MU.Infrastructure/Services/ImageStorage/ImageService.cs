using MediatR;
using MU.Application.Services.ImageService;

namespace MU.Infrastructure.Services.ImageStorage
{
    public class ImageService : IImageService
    {
        public string GetPathFile(string path)
        {
            throw new NotImplementedException();
        }

        public async Task UploadAsync(string pathDirectory, string nameFile, byte[] fileData)
        {
            if (!Directory.Exists(pathDirectory))
            {
                Directory.CreateDirectory(pathDirectory);
            }

            string exactPath = Path.Combine(pathDirectory, nameFile);
            await File.WriteAllBytesAsync(exactPath, fileData);
        }
    }
}
