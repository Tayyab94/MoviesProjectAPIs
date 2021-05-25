using Movies_APIs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Helpers
{
    public static class IQuerableExtensions
    {
        public static IQueryable<T>Paginate<T>(this IQueryable<T> querable, PaginationDTO paginationDTO)
        {
            return querable.Skip((paginationDTO.Page - 1) * paginationDTO.RecorsPerPage)
                .Take(paginationDTO.RecorsPerPage);
        }
    }
}
