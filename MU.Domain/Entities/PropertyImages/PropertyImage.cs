using MU.Domain.Entities.Properties;

namespace MU.Domain.Entities.PropertyImages
{
    public class PropertyImage
    {
        public PropertyImageId IdPropertyImage { get; set; }
        public PropertyId IdProperty { get; set; }
        public string File { get; set; } = string.Empty; // set only name of file
        public bool Enabled { get; set; }

        public virtual Property Property { get; set; }
    }
}
