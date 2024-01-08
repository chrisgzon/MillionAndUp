namespace MU.Domain.Interfaces
{
    public interface IList<TEntity, TEntityID>
    {
        Task<ICollection<TEntity>> ListAsync();
        Task<TEntity?> SearchByIdAsync(TEntityID entityId);
    }
}