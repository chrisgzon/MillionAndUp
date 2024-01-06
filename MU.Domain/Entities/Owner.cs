using System.Globalization;

namespace MU.Domain.Entities
{
    public class Owner
    {
        public int IdOwner { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public DateTime Birthay { get; set; }
        public bool Enabled { get; set; }

        public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}