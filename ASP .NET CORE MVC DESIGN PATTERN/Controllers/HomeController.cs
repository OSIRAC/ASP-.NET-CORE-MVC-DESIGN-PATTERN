using AutoMapper;
using EFCORE_VERİALMA.Models;
using EFCORE_VERİALMA.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFCORE_VERİALMA.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [Route("/")]  //DİREKTMEN AÇILINCA ÇAĞRILSIN DİYE BOŞŞSA URL AMA / KULLAN Kİ BELİRSİZLİK KALKSIN ÜSTTEKİ ETKİLEMESİN
        public IActionResult Index()
        {
            var products = _context.Products.OrderByDescending(x => x.Id).Select(x =>
            new ProductPartialViewModel() // SELECT VERİLEİRN HANGİ ŞEKİLDE DÖNÜŞTÜRECEĞİNİ VEYA SEÇİLECEĞİNİ BELİRLER
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock
            }).ToList();

            ViewBag.ProductListPartialViewModel = new ProductListPartialViewModel()
            {
                Products = products
            };

            return View();
        }

        public IActionResult Privacy()
        {

            var products = _context.Products.OrderByDescending(x => x.Id).Select(x =>
           new ProductPartialViewModel() // SELECT VERİLEİRN HANGİ ŞEKİLDE DÖNÜŞTÜRECEĞİNİ VEYA SEÇİLECEĞİNİ BELİRLER
           {
               Id = x.Id,
               Name = x.Name,
               Price = x.Price,
               Stock = x.Stock
           }).ToList();

            ViewBag.ProductListPartialViewModel = new ProductListPartialViewModel()
            {
                Products = products
            };


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            errorViewModel.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;


            return View(errorViewModel);
        }

        public IActionResult Visitor()
        {

            return View();
        }

        public IActionResult SaveVisitorCommet(VisitorViewModel visitorViewModel)
        {
            var visitor = _mapper.Map<Visitor>(visitorViewModel);

            visitor.Created = DateTime.Now;

            _context.Visitors.Add(visitor);
            _context.SaveChanges();

            TempData["result"] = "Yorum Kaydedilmiştir";

            return RedirectToAction(nameof(Visitor));
        }


    }
}