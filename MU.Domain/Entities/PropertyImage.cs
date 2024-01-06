namespace MU.Domain.Entities
{
    public class PropertyImage
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty {  get; set; }
        public string File { get; set; } = string.Empty;
        public bool Enabled { get; set; }

        public virtual Property Property { get; set; } = new Property();
    }
}
