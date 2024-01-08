using Microsoft.EntityFrameworkCore;
using MU.Domain.Entities.Properties;
using MU.Infrastructure.Contexts;

namespace MU.Infrastructure.Repositories
{
    public class PropertyRepository : IRepositoryProperty
    {
        private readonly MUContext _muContext;
        public PropertyRepository(MUContext muContext)
        {
            _muContext = muContext ?? throw new ArgumentNullException(nameof(muContext));
        }

        public async Task CreateAsync(Property entity) => await _muContext.Properties.AddAsync(entity);

        public Task<Property> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Property>> ListByFiltersAsync(Property entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Property?> SearchByIdAsync(PropertyId entityId) => await _muContext.Properties.SingleOrDefaultAsync(p => p.IdProperty == entityId);

        public void Update(Property entity)
        {
            throw new NotImplementedException();
        }
    }
}
