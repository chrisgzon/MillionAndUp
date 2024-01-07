using MU.Domain.Entities.Properties;
using MU.Domain.Interfaces;

namespace MU.Application.Interfaces
{
    public interface IServiceProperty
        : ICreate<Property>, IUpdate<Property>, IList<Property, int>
    {
        void ChangePrice(Property entity);
        List<Property> ListByFilters(Property entity);
    }
}
