using MU.Domain.Interfaces;

namespace MU.Application.Interfaces
{
    public interface IServiceBase<TEntity, TEntityID>
        : IAdd<TEntity>, IUpdate<TEntity>, IDelete<TEntityID>, IList<TEntity, TEntityID>
    {

    }
}
