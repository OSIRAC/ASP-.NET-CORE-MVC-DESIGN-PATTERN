using AutoMapper;
using EFCORE_VERİALMA.Filters;
using EFCORE_VERİALMA.Models;
using EFCORE_VERİALMA.Models.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;
using System;

namespace EFCORE_VERİALMA.Controllers
{

    public class Oyun
    {
        public string? toy { get; set; }

        public string? game { get; set; }
    }


    [LogFilter]
    [Route("[controller]/[action]")]  // BASE DE TANIMLADIM
    public class ProductsController : Controller
    {

        private  AppDbContext _context;

        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductsController(AppDbContext context, IMapper mapper) //DEPENDECY İNJECTİON DEVREDE
        {
            _productRepository = new ProductRepository();

            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            //var products = _productRepository.ListProducts();
            var products = _context.Products.ToList();

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }


        [ServiceFilter(typeof(NotFoundFilter))]
        [Route("Urunler/Urun/{productid}",Name ="product")] // CONTROLLER BURADA PRODUCTS İLE EŞLEŞİR WRAPLAMIDIR BU BİRNEVİ NAME PARAMETRESİ ASP-CONTROLLER,ACTİON YAZMAMIZDAN KURATIRI CSHTML SAYFASINDA
        public IActionResult GetById(int productid)
        {
            var product = _context.Products.Find(productid);
            return View(_mapper.Map<ProductViewModel>(product));

        }

        [Route("[controller]/[action]/{page}/{pageSize}")] //SPESİFİK BUNA ÖZEL ROUTELAR KARŞILANIR SADECE
        public IActionResult Pages(int page,int pageSize)
        {
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;

            var products = _context.Products.Skip((page - 1) * pageSize).Take(pageSize).ToList();// SKİP ATLAMAMIZI SAĞLAR 



            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")] // ÖNCESİNİ EN ÜSTTE TANIMLADIK
        public IActionResult Remove(int id)
        {
            //_productRepository.RemoveProduct(id);

            var products = _context.Products.Find(id);// PRİMARY KEYE GÖRE BULUR VE DÖNER

            _context.Products.Remove(products);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {


            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 ay",1 },
                {"3 ay",3 },
                {"6 ay",6 },
                {"12 ay",12 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorList>() { 
                               
                new ColorList() { Data = "Kırmızı" ,Value = "Kırmızı"},
                new ColorList() { Data = "MAVİ", Value = "MAVİ" },
                new ColorList() { Data = "SARI", Value = "SARI" }
            },"Value","Data");


            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            /*
            var name = HttpContext.Request.Form["Name"].ToString(); // HTTPCONTEXT GELEN İSTEKLERİN BİLGİLERİNİ İÇEEREN BİR NESNEDİR
            var price = int.Parse(HttpContext.Request.Form["Price"].ToString());
            var colour = HttpContext.Request.Form["Colour"].ToString();
            var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            
            Product product = new Product()
            {
                Name = name,
                Price = price,
                Colour = colour,
                Stock = stock
            };
            */

            ViewBag.Expire = new Dictionary<string, int>()
                {
                {"1 ay",1 },
                {"3 ay",3 },
                {"6 ay",6 },
                {"12 ay",12 }
                 };

            ViewBag.ColorSelect = new SelectList(new List<ColorList>() {

                new ColorList() { Data = "Kırmızı" ,Value = "Kırmızı"},
                new ColorList() { Data = "MAVİ", Value = "MAVİ" },
                new ColorList() { Data = "SARI", Value = "SARI" }
                }, "Value", "Data");

            if (ModelState.IsValid)
            { 
                try
                {
                    //throw new Exception("HATA OLDU");
                    TempData["status"] = "Ürün Başarı İle Eklendi";
                    _context.Products.Add(_mapper.Map<Product>(product));
                    _context.SaveChanges();

                    return RedirectToAction("Index");

                }
                catch (Exception)
                {

                    ModelState.AddModelError(string.Empty, "BEKLENMEYEN HATA OLUŞTU");
                    return View();
                }
            }
            else
            {
                return View();
            }
                      
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Update(int id)
        {

            var product = _context.Products.Find(id);

            ViewBag.ExpireValue = product.Expire;

            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 ay",1 },
                {"3 ay",3 },
                {"6 ay",6 },
                {"12 ay",12 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorList>() {

                new ColorList() { Data = "Kırmızı" ,Value = "Kırmızı"},
                new ColorList() { Data = "MAVİ", Value = "MAVİ" },
                new ColorList() { Data = "SARI", Value = "SARI" }
            }, "Value", "Data",product.Colour);

            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel upgradeproduct,int productid)// QUERY STRİNG OLRAK BÖYLE YAKALAYABİLİRİZ HYBRİD MODELDİR BUDA QUERY STRİNG HER TÜRDE İSTEKLE KARŞILANABİLİR GET VEYA POST
        {

            if(!ModelState.IsValid)
            {

                var product = _context.Products.Find(productid);

                ViewBag.ExpireValue = product.Expire;

                ViewBag.Expire = new Dictionary<string, int>()
                {
                {"1 ay",1 },
                {"3 ay",3 },
                {"6 ay",6 },
                {"12 ay",12 }
                };

                    ViewBag.ColorSelect = new SelectList(new List<ColorList>() {

                    new ColorList() { Data = "Kırmızı" ,Value = "Kırmızı"},
                    new ColorList() { Data = "MAVİ", Value = "MAVİ" },
                    new ColorList() { Data = "SARI", Value = "SARI" }
                    }, "Value", "Data", product.Colour);

                return View(_mapper.Map<ProductViewModel>(product));
            }                    
                upgradeproduct.Id = productid;
                _context.Products.Update(_mapper.Map<Product>(upgradeproduct));
                _context.SaveChanges();

                TempData["status"] = "Ürün Başarı İle Güncellendi";


                return RedirectToAction("Index");
            
        }
        [AcceptVerbs("GET","POST")]
        public IActionResult HasProdyctName(string Name)
        {

            var anyProduct = _context.Products.Any(p => p.Name == Name);

            if(anyProduct)
            {

                return Json("BU İSİM VARDIR");
            }
            else
            {
                return Json(true);
            }

        }

        public IActionResult Bind() // BURADA ZATEN BİR NEW() OYUN GİTTİĞİNİNDNE YENİ BİR TANE OLUŞMAZ BUNUN ÜZERİNDNE İŞLEM GÖRÜLÜR VE REFERANS TÜRÜNE BAĞLANIR KİM KARŞILIYORSA BÖYLELİKLE GÜNCELLEME YAPILABİLİR
        {
            Oyun oyun = new Oyun();
            oyun.game = "Saklanbaç";
            oyun.toy = "Bebek";


            return View();
        }
        /*
        [HttpPost]
        public IActionResult Bind(string toy,string game)
        {


            return View();
        }
        */
        /*
        [HttpPost] //POST İLE VERİLER BODY İLE TAŞINIR
        public IActionResult Bind(Oyun oyun) // POST İŞLEMİ TETİKLENMESİYLE YENİ BİR NEW OYUN() OLUŞTURULUR VE KULLANICI VERİLERİ DOLAR
        {


            return View();
        }
        */
        /*
        [HttpPost]
        public IActionResult Bind(IFormCollection datas) IFORMCOLLECTION FORMDAN GELEN VERİELRİ BÖYLE ALMAMIZI SAĞLAR
        {
            var value = datas["toy"];
            var value2 = datas["game"];


            return View();
        }
        */
        /*
        [HttpPost]
        public IActionResult Bind() 
        {
            var value = Request.Form["toy"].ToString(); // FORMDAN GELENLERİ ALDIK BÖYLE
            var value1 = Request.Form["game"].ToString();

            return View();
        }
        */
        /*
        public IActionResult Bind(int index)
        {      
            var value = Request.Query["index"]; BU ŞEKİLDEDE QUERY STRİNGİ ALABİLİRSİN

            return View();   // GET İLE DE VERİ YOLLAYABİLİRİSN AMA BU SEFERDE VERİ QUERY STRİNG İLE GİDER SAĞLIKLI OLMAZ
        }
        */
        Form form = new Form();
                 
        
        public IActionResult Form()
        {

           form.IsRead = true;
           form.Name = "ömer";
           form.Expire = 6;
            form.Color = "SARI";
            ViewBag.ExpireValue = form.Expire;

            ViewBag.ColorSelect = new SelectList(new List<ColorList>() {

                new ColorList() { Data = "Kırmızı" ,Value = "Kırmızı"},
                new ColorList() { Data = "MAVİ", Value = "MAVİ" },
                new ColorList() { Data = "SARI", Value = "SARI" }
            }, "Value", "Data");


            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 ay",1 },
                {"3 ay",3 },
                {"6 ay",6 },
                {"12 ay",12 }
            };


            return View(form);
        }
        /*
        public IActionResult Form()
        {
            ViewBag.ColorSelect = new SelectList(new List<ColorList>() {

                new ColorList() { Data = "Kırmızı" ,Value = "Kırmızı"},
                new ColorList() { Data = "MAVİ", Value = "MAVİ" },
                new ColorList() { Data = "SARI", Value = "SARI" }
            }, "Value", "Data", form.Color = "MAVİ");

            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 ay",1 },
                {"3 ay",3 },
                {"6 ay",6 },
                {"12 ay",12 }
            };


            return View();
        }
        */
        [HttpPost]
        public IActionResult Form(Form form)
        {
         


            return View("Index2",form);
        }

        /*
        public IActionResult Index2()
        {


            return View(form);
        }
        */
    }
}
