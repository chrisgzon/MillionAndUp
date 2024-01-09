using Microsoft.EntityFrameworkCore;
using MU.Domain.Entities.PropertyImages;
using MU.Domain.Interfaces.Repositories;
using MU.Infrastructure.Contexts;

namespace MU.Infrastructure.Persistence.Repositories
{
    public class PropertyImageRepository : IRepositoryPropertyImage
    {
        private readonly MUContext _muContext;

        public PropertyImageRepository(MUContext muContext)
        {
            _muContext = muContext;
        }

        public Task CreateAsync(PropertyImage entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<PropertyImage>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PropertyImage?> SearchByIdAsync(PropertyImageId entityId) => _muContext.PropertyImages.SingleOrDefaultAsync(i => i.IdPropertyImage == entityId);

        public void Update(PropertyImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
