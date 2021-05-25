using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Helpers
{
    public static class HttpContextExtensions
    {

        public async static Task InsertParametersPaginationInHeader<T>(this HttpContext httpContext,
            IQueryable<T> qurable)
        {
            if(httpContext== null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            double count = await qurable.CountAsync();

            httpContext.Response.Headers.Add("totalAmountOfRecords", count.ToString());
        }
    }
}
