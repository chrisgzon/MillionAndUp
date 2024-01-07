namespace MU.Domain.Interfaces
{
    public interface ICreate<TEntity>
    {
        Task Create(TEntity entity);
    }
}
