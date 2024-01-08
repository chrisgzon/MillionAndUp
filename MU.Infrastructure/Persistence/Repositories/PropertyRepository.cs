using Microsoft.EntityFrameworkCore;
using MU.Domain.Entities;
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
        public Task ChangePrice(Property entity)
        {
            throw new NotImplementedException();
        }

        public async Task Create(Property entity) => await _muContext.Properties.AddAsync(entity);

        public async Task<ICollection<Property>> ListAsync()
        {
            return await _muContext.Properties.Select(p => new Property
            {
                Name = p.Name,
                IdProperty = p.IdProperty,
                Owner = p.Owner,
                Address = Domain.ValueObjects.Address.Create(p.Address.City, p.Address.State, p.Address.Line1, p.Address.Line2, p.Address.ZipCode),
                CodeInternal = p.CodeInternal,
                Enabled = p.Enabled,
                IdOwner = p.IdOwner,
                PriceSale = p.PriceSale,
                YearBuild = p.YearBuild,
            }).Take(30).ToListAsync();
        }

        public Task<List<Property>> ListByFilters(Property entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Property?> SearchByIdAsync(int entityId) => await _muContext.Properties.SingleOrDefaultAsync(p => p.IdProperty == entityId);

        public Task Update(Property entity)
        {
            throw new NotImplementedException();
        }
    }
}
