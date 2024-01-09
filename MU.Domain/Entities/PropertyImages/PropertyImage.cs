using MU.Domain.Entities.Properties;

namespace MU.Domain.Entities.PropertyImages
{
    public class PropertyImage
    {
        public PropertyImage(PropertyImageId idPropertyImage, PropertyId idProperty, string file, bool enabled, string? pathFolder, byte[]? fileData, long? fileLength)
        {
            IdPropertyImage = idPropertyImage;
            IdProperty = idProperty;
            File = file;
            Enabled = enabled;
            PathFolder = pathFolder;
            FileData = fileData;
            FileLength = fileLength;
        }

        private PropertyImage() { }

        public PropertyImageId IdPropertyImage { get; private set; }
        public PropertyId IdProperty { get; private set; }
        public string File { get; private set; } = string.Empty; // set path complete of file
        public bool Enabled { get; private set; }

        public string? PathFolder {  get; private set; }
        public byte[]? FileData { get; private set; }
        public long? FileLength { get; private set; }

        public Property? Property { get; private set; }
    }
}
