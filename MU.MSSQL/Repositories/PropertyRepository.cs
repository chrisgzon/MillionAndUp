using MU.Domain.Entities;
using MU.Domain.Interfaces.Repositories;
using MU.MSSQL.Contexts;

namespace MU.MSSQL.Repositories
{
    public class PropertyRepository : IRepositoryProperty
    {
        private readonly MUContext MUContext;
        public PropertyRepository(MUContext context)
        {
            MUContext = context;
        }
        public Property Add(Property entity)
        {
            throw new NotImplementedException();
        }

        public void ChangePrice(Property entity)
        {
            throw new NotImplementedException();
        }

        public Property List()
        {
            throw new NotImplementedException();
        }

        public List<Property> ListByFilters(Property entity)
        {
            throw new NotImplementedException();
        }

        public Property SearchByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(Property entity)
        {
            throw new NotImplementedException();
        }
    }
}
