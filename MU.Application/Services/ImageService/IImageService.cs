namespace MU.Application.Services.ImageService
{
    public interface IImageService
    {
        Task UploadAsync(string pathDirectory, string nameFile, byte[] fileData);
        string GetPathFile(string path);
    }
}