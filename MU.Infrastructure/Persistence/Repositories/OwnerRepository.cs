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

        public Task CreateAsync(Owner entity)
        {
            throw new NotImplementedException();
        }

        public Task<Owner> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Owner?> SearchByIdAsync(OwnerId entityId) => await _muContext.Owners.Include("_properties").SingleOrDefaultAsync(x => x.IdOwner == entityId);

        public void Update(Owner entity) => _muContext.Owners.Update(entity);
    }
}