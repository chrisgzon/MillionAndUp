using MU.Application.Interfaces;
using MU.Domain.Entities;
using MU.Domain.Interfaces.Repositories;

namespace MU.Application.Services
{
    public class ServiceProperty : IServiceProperty
    {
        private readonly IRepositoryProperty repositoryProperty;
        private readonly IRepositoryBase<Owner, int> repositoryOwner;
        private readonly IRepositoryBase<PropertyImage, int> repositoryPropertyImage;
        private readonly IRepositoryBase<PropertyTrace, int> repositoryPropertyTrace;
        public ServiceProperty(IRepositoryProperty _repositoryProperty,
            IRepositoryBase<Owner, int> _repositoryOwner,
            IRepositoryBase<PropertyImage, int> _repositoryPropertyImage,
            IRepositoryBase<PropertyTrace, int> _repositoryPropertyTrace
            ) 
        {
            repositoryProperty = _repositoryProperty;
            repositoryOwner = _repositoryOwner;
            repositoryPropertyImage = _repositoryPropertyImage;
            repositoryPropertyTrace = _repositoryPropertyTrace;
        }

        public Property Add(Property entity)
        {
            if ( entity is null )
                throw new NotImplementedException();

            return repositoryProperty.Add( entity );
        }

        public void ChangePrice(Property entity)
        {
            if ( entity is null )
                throw new ArgumentException("La Propiedad es requerida.");

            if (entity.IdProperty == 0)
                throw new ArgumentException("El identificador de la propiedad no es valido.");

            if (entity.PriceSale <= 0)
                throw new ArgumentException("El precio de la propiedad debe ser superior a 0.");

            repositoryProperty.ChangePrice( entity );
        }

        public void Update(Property entity)
        {
            if (entity is null)
                throw new ArgumentNullException("La Propiedad es requerida.");

            if (entity.IdProperty == 0)
                throw new ArgumentException("El identificador de la propiedad no es valido.");

            if (entity.PriceSale <= 0)
                throw new ArgumentException("El precio de la propiedad debe ser superior a 0.");

            if (String.IsNullOrEmpty(entity.Address))
                throw new ArgumentException("La direccion de la propiedad es requerida");

            if (entity.IdOwner == 0 && entity.Owner.IdOwner == 0)
                throw new ArgumentException("No se recibio el identificador del dueño de la propiedad");

            if (String.IsNullOrEmpty(entity.Name))
                throw new ArgumentException("El nombre de la propiedad es requerido");

            repositoryProperty.Update( entity );
        }

        public Property List()
        {
            throw new NotImplementedException();
        }

        public Property SearchByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<Property> ListByFilters(Property entity)
        {
            if (entity is null)
                throw new ArgumentException("No se recibio ningún parametro para realizar el filtro de las propiedades.");

            return repositoryProperty.ListByFilters( entity );
        }
    }
}