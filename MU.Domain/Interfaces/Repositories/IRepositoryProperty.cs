using MU.Domain.Interfaces.Repositories;

namespace MU.Domain.Entities.Properties
{
    public interface IRepositoryProperty
        : IRepositoryBase<Property, PropertyId>
    {
        Task<List<Property>> ListByFiltersAsync(Property entity);
    }
}
