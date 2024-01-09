using Microsoft.EntityFrameworkCore;
using MU.Domain.Entities.Owners;
using MU.Domain.Interfaces.Repositories;
using MU.Infrastructure.Contexts;

namespace MU.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : IRepositoryOwner
    {
        private readonly MUContext _muContext;

        public OwnerRepository(MUContext muContext)
        {
            _muContext = muContext;
        }

        public async Task CreateAsync(Owner entity) => await _muContext.Owners.AddAsync(entity);

        public Task<List<Owner>> ListAsync() => _muContext.Owners.Include(o => o._properties).ToListAsync();

        public async Task<Owner?> SearchByIdAsync(OwnerId entityId) => await _muContext.Owners.Include("_properties").SingleOrDefaultAsync(x => x.IdOwner == entityId);

        public void Update(Owner entity) => _muContext.Owners.Update(entity);
    }
}