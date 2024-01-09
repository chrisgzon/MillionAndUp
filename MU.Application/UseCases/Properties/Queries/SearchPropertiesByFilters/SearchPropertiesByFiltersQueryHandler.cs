using ErrorOr;
using MediatR;
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

            if (!String.IsNullOrWhiteSpace(request.SearchTerm))
            {
                propertiesQuery = propertiesQuery.Where(p =>
                    p.Name.Contains(request.SearchTerm) ||
                    ((string)p.CodeInternal).Contains(request.SearchTerm) ||
                    (p.Address.City+", "+p.Address.State + ", " +p.Address.Line1 + " " + p.Address.Line2 + ", " +p.Address.ZipCode).Contains(request.SearchTerm)
                );
            }

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
                    p.IdOwner.Value
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