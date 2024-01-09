using MU.Domain.Interfaces.Repositories;

namespace MU.Domain.Entities.Properties
{
    public interface IRepositoryProperty
        : IRepositoryBase<Property, PropertyId>
    {
        IQueryable<Property> SearchByFilters();
    }
}