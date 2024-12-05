using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    public static class PaginationExtension
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> superset, int page, int pageSize)
        {
            if (page <= 0)
                page = 1;
            if (pageSize <= 0)
                pageSize = 1;

            return new PagedList<T>
            {
                Items = superset.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(superset.Count() / (double)pageSize),
                PageSize = pageSize,
                TotalItems = superset.Count(),
                RemaingItems = superset.Count() - (page * pageSize)
            };

        }
    }
}
