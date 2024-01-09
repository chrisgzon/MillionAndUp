using ErrorOr;
using MediatR;

namespace MU.Application.UseCases.Properties.Queries.SearchPropertiesByFilters
{
    public record SearchPropertiesByFiltersQuery(
        string? SearchTerm,
        string? SortColumn,
        string? SortOrder,
        int Page,
        int PageSize) : IRequest<ErrorOr<PagedList<PropertyResponse>>>;
}
