namespace MU.Domain.Interfaces
{
    public interface IList<TEntity, TEntityID>
    {
        TEntity List();
        TEntity SearchByID(TEntityID entityId);
    }
}