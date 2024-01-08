using MU.Domain.Interfaces;

namespace MU.Domain.Entities.Properties
{
    public interface IRepositoryProperty
        : ICreate<Property>, IUpdate<Property>, IList<Property, int>
    {
        Task ChangePrice(Property entity);
        Task<List<Property>> ListByFilters(Property entity);
    }
}
