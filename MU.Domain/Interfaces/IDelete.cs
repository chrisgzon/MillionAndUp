namespace MU.Domain.Interfaces
{
    public interface IDelete<TEntityID>
    {
        void Delete(TEntityID entityID);
    }
}
