using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Movies_APIs.CustomActionFilters
{
    public class MyActionFilter : IActionFilter
    {
        private readonly ILogger<MyActionFilter> logger;

        public MyActionFilter(ILogger<MyActionFilter> logger)
        {
            this.logger = logger;
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogWarning("Excuting Method is calling");

            // Do something before the action executes.
            Debug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogWarning("Excuted Method is calling");

            Debug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
        }

    }
}
