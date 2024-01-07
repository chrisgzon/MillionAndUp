using MU.Domain.Interfaces;

namespace MU.Application.Interfaces
{
    public interface IServiceBase<TEntity, TEntityID>
        : ICreate<TEntity>, IUpdate<TEntity>, IList<TEntity, TEntityID>
    {

    }
}
