using MU.Domain.Entities;
using MU.Domain.Interfaces;

namespace MU.Application.Interfaces
{
    public interface IServiceProperty
        : IAdd<Property>, IUpdate<Property>, IList<Property, int>
    {
        void ChangePrice(Property entity);
        List<Property> ListByFilters(Property entity);
    }
}
