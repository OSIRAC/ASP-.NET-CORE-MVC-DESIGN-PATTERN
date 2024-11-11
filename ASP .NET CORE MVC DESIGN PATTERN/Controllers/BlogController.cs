using Microsoft.AspNetCore.Mvc;

namespace EFCORE_VERİALMA.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Article()
        {
            var routes = Request.RouteValues["article"];

            return View();
        }
    }
}
