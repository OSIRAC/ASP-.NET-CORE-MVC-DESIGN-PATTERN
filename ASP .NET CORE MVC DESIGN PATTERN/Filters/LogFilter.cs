﻿using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace EFCORE_VERİALMA.Filters
{
    public class LogFilter : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Action method çalışmadan sonra");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Action method çalışmadan önce");
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Debug.WriteLine("Action method sonuç üretilmeden önce");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Debug.WriteLine("Action method sonuç üretilmeden sonra");
        }
    }
}
