﻿using Microsoft.EntityFrameworkCore;

namespace MU.Application.UseCases.Properties.Queries.SearchPropertiesByFilters
{
    public class PagedList<T>
    {
        public PagedList(List<T> items, int page, int pageSize, int totalCount)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public List<T> Items { get; }
        public int Page { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public bool HasNextPage => Page * PageSize < TotalCount;
        public bool HasPreviousPage => Page > 1;

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize)
        {
            page = page == 0 ? 1 : page;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int totalCount = await query.CountAsync();
            List<T> items = await query.Skip((page-1) * pageSize).Take(pageSize).ToListAsync();

            return new(items, page, pageSize, totalCount);
        }
    }
}
