using MU.Domain.Entities.Properties;
using MU.Domain.Primitives;

namespace MU.Domain.Entities.PropertyImages
{
    public class PropertyImage
    {
        public PropertyImage(PropertyImageId idPropertyImage, PropertyId idProperty, string file, bool enabled, Property property)
        {
            IdPropertyImage = idPropertyImage;
            IdProperty = idProperty;
            File = file;
            Enabled = enabled;
            Property = property;
        }

        private PropertyImage() { }
        public PropertyImageId IdPropertyImage { get; private set; }
        public PropertyId IdProperty { get; private set; }
        public string File { get; set; } = string.Empty;
        public bool Enabled { get; private set; }

        public virtual Property? Property { get; private set; }
    }
}
