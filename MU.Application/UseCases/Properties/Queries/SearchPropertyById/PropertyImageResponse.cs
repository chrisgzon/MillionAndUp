namespace MU.Application.UseCases.Properties.Queries.SearchPropertyById
{
    public class PropertyImageResponse
    {
        public PropertyImageResponse(Guid idPropertyImageResponse, Guid idPoperty, string pathFile, bool enabled)
        {
            IdPropertyImageResponse = idPropertyImageResponse;
            IdPoperty = idPoperty;
            PathFile = pathFile;
            Enabled = enabled;
        }

        public Guid IdPropertyImageResponse { get; }
        public Guid IdPoperty { get; }
        public string PathFile { get; }
        public bool Enabled { get; }
    }
}
