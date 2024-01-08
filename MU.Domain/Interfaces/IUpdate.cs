namespace MU.Domain.Interfaces
{
    public interface IUpdate<TEntity>
    {
        void Update(TEntity entity);
    }
}