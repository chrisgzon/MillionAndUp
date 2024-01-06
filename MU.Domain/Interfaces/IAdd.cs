namespace MU.Domain.Interfaces
{
    public interface IAdd<TEntity>
    {
        TEntity Add(TEntity entity);
    }
}
