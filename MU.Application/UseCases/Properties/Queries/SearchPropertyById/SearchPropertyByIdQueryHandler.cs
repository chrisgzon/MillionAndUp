﻿using ErrorOr;
using MediatR;
using MU.Domain.Entities.Properties;

namespace MU.Application.UseCases.Properties.Queries.SearchPropertyById
{
    internal sealed class SearchPropertyByIdQueryHandler : IRequestHandler<SearchPropertyByIdQuery, ErrorOr<Property>>
    {
        private readonly IRepositoryProperty _repositoryProperty;

        public SearchPropertyByIdQueryHandler(IRepositoryProperty repositoryProperty)
        {
            _repositoryProperty = repositoryProperty ?? throw new ArgumentNullException(nameof(repositoryProperty));
        }

        public async Task<ErrorOr<Property>> Handle(SearchPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            Property? Property = await _repositoryProperty.SearchByIdAsync(new PropertyId(request.propertyId));
            if (Property is null)
                return PropertyErrors.propertyNotFound;

            return Property;
        }
    }
}