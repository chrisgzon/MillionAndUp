using MU.Domain.Entities.Properties;
using MU.Domain.Interfaces;

namespace MU.Domain.Entities.Properties
{
    public interface IRepositoryProperty
        : ICreate<Property>, IUpdate<Property>, IList<Property, PropertyId>
    {
        Task ChangePrice(Property entity);
        Task<List<Property>> ListByFilters(Property entity);
    }
}
