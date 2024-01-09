namespace MU.Application.UseCases.Properties.Queries.SearchPropertiesByFilters
{
    public class PropertyResponse
    {
        public PropertyResponse(Guid idProperty, string nameProperty, int yearBuild, string address, string codeInternal, Guid idOwner)
        {
            IdProperty = idProperty;
            NameProperty = nameProperty;
            YearBuild = yearBuild;
            Address = address;
            CodeInternal = codeInternal;
            IdOwner = idOwner;
        }

        public Guid IdProperty {  get; }
        public string NameProperty { get; }
        public int YearBuild {  get; }
        public string Address { get; }
        public string CodeInternal { get; }
        public Guid IdOwner { get; }
    }
}
