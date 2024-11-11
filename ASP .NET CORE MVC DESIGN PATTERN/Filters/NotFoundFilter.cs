using EFCORE_VERİALMA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;

namespace EFCORE_VERİALMA.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        public readonly AppDbContext _context;

        public NotFoundFilter(AppDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
           var idValue = context.ActionArguments.Values.First();

            var id = (int)idValue;

            var hasproduct = _context.Products.Any(x => x.Id == id);

            if (hasproduct==false)
            {

                context.Result = new RedirectToActionResult("Error", "Home", new ErrorViewModel()
                {
                    Errors = new List<string>() {$"ID ({id})YE SAHİP ÜRÜN VERİ TABANINDA BULUNAMAMIŞTIR"}
                });
            }
        }
    }
}
