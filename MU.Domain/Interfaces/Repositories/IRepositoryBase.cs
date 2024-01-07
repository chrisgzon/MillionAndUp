namespace MU.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity, TEntityID>
        : ICreate<TEntity>, IUpdate<TEntity>, IList<TEntity, TEntityID>
    {

    }
}