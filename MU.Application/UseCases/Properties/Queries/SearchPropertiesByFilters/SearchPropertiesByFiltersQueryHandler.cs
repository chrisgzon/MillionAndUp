using ErrorOr;
using MediatR;
using MU.Application.UseCases.Properties.Queries.SearchPropertyById;
using MU.Domain.Entities.Properties;
using MU.Domain.Primitives;
using MU.Domain.ValueObjects;
using System.Linq.Expressions;
using System.Reflection.Emit;

namespace MU.Application.UseCases.Properties.Queries.SearchPropertiesByFilters
{
    internal sealed class SearchPropertiesByFiltersQueryHandler : IRequestHandler<SearchPropertiesByFiltersQuery, ErrorOr<PagedList<PropertyResponse>>>
    {
        private readonly IRepositoryProperty _repositoryProperty;
        private readonly IUnitOfWork _unitOfWork;

        public SearchPropertiesByFiltersQueryHandler(IRepositoryProperty repositoryProperty, IUnitOfWork unitOfWork)
        {
            _repositoryProperty = repositoryProperty ?? throw new ArgumentNullException(nameof(repositoryProperty));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<PagedList<PropertyResponse>>> Handle(SearchPropertiesByFiltersQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Property> propertiesQuery = _repositoryProperty.SearchByFilters();

            if (!String.IsNullOrWhiteSpace(request.NameProperty))
                propertiesQuery = propertiesQuery.Where(p => p.Name.Contains(request.NameProperty));
            if (!String.IsNullOrWhiteSpace(request.Address))
                propertiesQuery = propertiesQuery.Where(p => (p.Address.City + ", " + p.Address.State + ", " + p.Address.Line1 + " " + p.Address.Line2 + ", " + p.Address.ZipCode).Contains(request.Address));
            if (!String.IsNullOrWhiteSpace(request.CodeInternal))
                propertiesQuery = propertiesQuery.Where(p => ((string)p.CodeInternal).Contains(request.CodeInternal));
            if (request.PriceSale.HasValue)
                propertiesQuery = propertiesQuery.Where(p => p.PriceSale.Equals(request.PriceSale));
            if (request.YearBuild.HasValue)
                propertiesQuery = propertiesQuery.Where(p => p.YearBuild.Equals(request.YearBuild));
            if (request.Enabled.HasValue)
                propertiesQuery = propertiesQuery.Where(p => p.Enabled.Equals(request.Enabled));
            if (request.IdOwner.HasValue)
                propertiesQuery = propertiesQuery.Where(p => p.IdOwner.Equals(request.IdOwner));

            if (request.SortOrder?.ToLower() == "desc")
            {
                propertiesQuery = propertiesQuery.OrderByDescending(GetSortProperty(request.SortColumn));
            }
            else
            {
                propertiesQuery = propertiesQuery.OrderBy(GetSortProperty(request.SortColumn));
            }

            var propertiesResponseQuery = propertiesQuery
                .Select(p => new PropertyResponse(
                    p.IdProperty.Value,
                    p.Name,
                    p.YearBuild,
                    p.Address.AddressString,
                    p.CodeInternal.Value,
                    p.Enabled,
                    p.IdOwner.Value,
                    p.PropertyImages.Select(i => new PropertyImageResponse(
                        i.IdPropertyImage.Value,
                        i.IdProperty.Value,
                        i.File,
                        i.Enabled)
                    ).ToList()
                ));

            PagedList<PropertyResponse> properties = await PagedList<PropertyResponse>.CreateAsync(
                propertiesResponseQuery,
                request.Page,
                request.PageSize);

            return properties;
        }

        private static Expression<Func<Property, object>> GetSortProperty(string? sortColumn)
        {
            Expression<Func<Property, object>> keySelector = sortColumn?.ToLower() switch
            {
                "name" => Property => Property.Name,
                "CodeInternal" => Property => Property.CodeInternal,
                "Address" => Property => Property.Address,
                "YearBuild" => Property => Property.CodeInternal,
                "PriceSale" => Property => Property.PriceSale,
                "IdOwner" => Property => Property.IdOwner,
                _ => prperty => prperty.Name,
            };
            return keySelector;
        }
    }
}