namespace MU.Domain.Entities
{
    public class PropertyImage
    {
        public PropertyImage(int idPropertyImage, int idProperty, string file, bool enabled, Property property)
        {
            IdPropertyImage = idPropertyImage;
            IdProperty = idProperty;
            File = file;
            Enabled = enabled;
            Property = property;
        }

        private PropertyImage() { }
        public int IdPropertyImage { get; private set; }
        public int IdProperty { get; private set; }
        public string File { get; set; } = string.Empty;
        public bool Enabled { get; private set; }

        public virtual Property? Property { get; private set; }
    }
}
