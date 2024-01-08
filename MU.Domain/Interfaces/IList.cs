namespace MU.Domain.Interfaces
{
    public interface IList<TEntity, TEntityID>
    {
        Task<TEntity> ListAsync();
        Task<TEntity?> SearchByIdAsync(TEntityID entityId);
    }
}