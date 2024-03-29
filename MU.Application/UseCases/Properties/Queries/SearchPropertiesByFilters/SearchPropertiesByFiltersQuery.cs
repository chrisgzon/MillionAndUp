﻿using ErrorOr;
using MediatR;
using MU.Application.UseCases.Properties.Queries.SearchPropertyById;

namespace MU.Application.UseCases.Properties.Queries.SearchPropertiesByFilters
{
    public record SearchPropertiesByFiltersQuery(
        string? NameProperty,
        string? Address,
        string? CodeInternal,
        int? PriceSale,
        int? YearBuild,
        bool? Enabled,
        Guid? IdOwner,
        string? SortOrder,
        string? SortColumn,
        int Page,
        int PageSize) : IRequest<ErrorOr<PagedList<PropertyResponse>>>;
}
