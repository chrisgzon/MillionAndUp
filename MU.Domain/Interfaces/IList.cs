namespace MU.Domain.Interfaces
{
    public interface IList<TEntity, TEntityID>
    {
        Task<List<TEntity>> ListAsync();
        Task<TEntity?> SearchByIdAsync(TEntityID entityId);
    }
}