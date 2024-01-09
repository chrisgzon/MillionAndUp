using MediatR;
using Microsoft.EntityFrameworkCore;
using MU.Application.UseCases.Properties.Queries.SearchPropertiesByFilters;
using MU.Domain.Entities.Properties;
using MU.Domain.ValueObjects;
using MU.Infrastructure.Contexts;
using System.Linq.Expressions;

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

        public async Task<List<Property>> ListAsync() => await _muContext.Properties.Include(p => p.Owner).Include(p => p.PropertyImages).ToListAsync();

        public IQueryable<Property> SearchByFilters() => _muContext.Properties.Include(p => p.PropertyImages).AsNoTracking();

        public async Task<Property?> SearchByIdAsync(PropertyId entityId) => await _muContext.Properties.Include(p => p.Owner).Include(p => p.PropertyImages).SingleOrDefaultAsync(p => p.IdProperty == entityId);

        public void Update(Property entity) => _muContext.Properties.Update(entity);
    }
}