namespace MU.Application.UseCases.Properties.Queries.SearchPropertyById
{
    public class PropertyResponse
    {
        public PropertyResponse(Guid idProperty, string nameProperty, int yearBuild, string address, string codeInternal, bool enabled, Guid idOwner, List<PropertyImageResponse> images)
        {
            IdProperty = idProperty;
            NameProperty = nameProperty;
            YearBuild = yearBuild;
            Address = address;
            CodeInternal = codeInternal;
            IdOwner = idOwner;
            Enabled = enabled;
            Images = images;
        }

        public Guid IdProperty { get; }
        public string NameProperty { get; }
        public int YearBuild { get; }
        public string Address { get; }
        public string CodeInternal { get; }
        public bool Enabled { get; }
        public Guid IdOwner { get; }
        public List<PropertyImageResponse> Images { get; }
    }
}
