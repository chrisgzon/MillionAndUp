namespace MU.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity, TEntityID>
        : IAdd<TEntity>, IUpdate<TEntity>, IDelete<TEntityID>, IList<TEntity, TEntityID>
    {

    }
}