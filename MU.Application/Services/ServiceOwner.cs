using MU.Application.Interfaces;
using MU.Domain.Entities;
using MU.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.Application.Services
{
    public class ServiceOwner : IServiceBase<Owner, int>
    {
        private readonly IRepositoryBase<Owner, int> repositoryOwner;
        public ServiceOwner(IRepositoryBase<Owner, int> _repositoryOwner)
        {
            repositoryOwner = _repositoryOwner;
        }
        public Owner Add(Owner entity)
        {
            if (entity is null)
                throw new ArgumentException("El Propietario es requerido.");

            Owner resultAddOwner = repositoryOwner.Add(entity);
            return resultAddOwner;
        }

        public void Delete(int entityID)
        {
            repositoryOwner.Delete(entityID);
        }

        public void Update(Owner entity)
        {
            if (entity is null)
                throw new ArgumentException("El Propietario es requerido para editar.");

            repositoryOwner.Update(entity);
        }

        public Owner List()
        {
            return repositoryOwner.List();
        }

        public Owner SearchByID(int entityId)
        {
            return SearchByID(entityId);
        }
    }
}
