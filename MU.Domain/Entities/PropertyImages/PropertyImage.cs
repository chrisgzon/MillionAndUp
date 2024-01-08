using MU.Domain.Entities.Properties;

namespace MU.Domain.Entities.PropertyImages
{
    public class PropertyImage
    {
        public PropertyImageId IdPropertyImage { get; set; }
        public PropertyId IdProperty { get; set; }
        public string File { get; set; } = string.Empty;
        public bool Enabled { get; set; }

        public virtual Property Property { get; set; }
    }
}
