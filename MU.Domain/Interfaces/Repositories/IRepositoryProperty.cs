using MU.Domain.Entities;

namespace MU.Domain.Interfaces.Repositories
{
    public interface IRepositoryProperty
        : IAdd<Property>, IUpdate<Property>, IList<Property, int>
    {
        void ChangePrice(Property entity);
        List<Property> ListByFilters(Property entity);
    }
}
