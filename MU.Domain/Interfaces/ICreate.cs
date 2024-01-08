namespace MU.Domain.Interfaces
{
    public interface ICreate<TEntity>
    {
        Task CreateAsync(TEntity entity);
    }
}
