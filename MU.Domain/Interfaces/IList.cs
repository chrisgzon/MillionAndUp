namespace MU.Domain.Interfaces
{
    public interface IList<TEntity, TEntityID>
    {
        Task<TEntity> List();
        Task<TEntity?> SearchByIdAsync(TEntityID entityId);
    }
}