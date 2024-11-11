using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using System.Diagnostics;

namespace MyAspNetCoreApp.Web.Controllers  // CONTROLLER ADI : CONTROLLERADI + CONTROLLER OLUR IDE CONTROLLER OLDUĞUNU ONUN BURADAN ANLAR TETİKLEDİĞİ METHODUN VİEWİ CONTROLLER ADI KLASÖRÜNÜN ADI ALTINDA OLMALIDIR VE METHOD ADIYLA AYNI CSHTML DOSYASI BULUNUR ONUN DIŞINDA CONTROLLERS İSMİ KEYFİDİR YALNIZ VİEWS İSMİ KEYFİ DEĞİLDİR SEN YİNE DE BEST PRACTİSE E UY AMA
{
    class Products
    {
        public int Id { get; set; }

        public string? Name { get; set; }

    }
    #region CONTROLLARDAN VİEWE TAŞIMA
    /*
     TEMPDATA
     VİEWBAG
     VİEWDATA
     VİEWMODEL
    */
    #endregion

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) 
        {
            _logger = logger;
        }
        [NonAction] // DIŞARIDAN REQUEST ALMAZLAR
        public void X()  // CONTROLLERIN İÇİNDEKİ HERŞEY ACTION METHODDUR YANİ URL İLE TETİKLENEBİLİR
        {

        }

        public IActionResult Product()
        {
            var propduct = new List<Products>()  // VİEWMODEL METHODU BUDA
            {
                new Products { Id = 1,Name ="OMER"},
                new Products { Id = 2,Name ="EMİR"}
            };
            return View(propduct);
        }


        public IActionResult Index() // INDEX METHODUNA KARŞILIK HOME CONTROLLERINININ İÇİNDE INDEX SAYFASI BULUNUR KALÖRÜN ADI HOME OLMALIDIR ÇÜNKÜ CONTROLLERIN ADI HOME DUR
        {
            ViewResult result = View(); // VİEW("EMİR") YAZARSAK ADI BİZİM TARAFIMIZDAN VERİLMİŞ EMİR.CSHTML ÇAĞRILCAKTIR

            var soyad = TempData["surname"];

            return result; // RESULT TARAYICIDA ÇALIŞTIRILIR VE GÖRÜRÜZ
        }      
        public JsonResult JsonResult(int id) // GERİYE SADECE VİEW DÖNÜYORDAK CSHTML Lİ KISIM OLUŞTURURUZ 
        {   // PARAMETRELİ METHODLA ROUTE DAKİ DEĞERİ YAKALAYABİLİRİZ YALNIZ İD PROGRAM.SC DEKİYLE AYNI OLMALIDIR
            JsonResult result = Json(new Product
            {
                Id = id,   //BİR NESNENİN JSON FORMATINI DÖNEBİLİRİZDE
               Name = "ELMA"
            });
            return result;   
        }
        public ActionResult ActionResult(int id) // IACTİONRESULT BUNA İMPLEMENTE EDER HER TÜRÜ İNREFACEDEKİ OLDUĞU GİBİ DÖNDÜREBİLİRİSN
        {   // ANONİM CLASSLA ANAHTAR ÇİFİT OLRAK GÖNDERİRİZ İLK İD YÖNELTTİĞİN DEĞERİ GÖSTERİR
            return RedirectToAction("JsonResult", "Home", new{ id = id }); // HOME CONTROLLERIN INDEXİNE YÖNLENDİREM YAPIYORUM
           
        }
        public EmptyResult EmptyResult()
        {           
            return new EmptyResult();
        }

        public ContentResult ContentResult()
        {
            ContentResult result = Content("NEDEN");  // BURADA BİR TEXT DÖNER AMA TERCİH EDİLMEZ ÇÜNKÜ GELENDE HTML FORMATTA OLMASINI İSTERİZ                                                
            return result;
        }
        public IActionResult Privacy()
        {
            ViewBag.name = "ASP.NETCORE";  // DİNAMİK OLRAK VERİ TAŞIR VİEWDEN CONTROLLARA
            ViewBag.ad = new List<string>() { "EMİR", "ÖMER" }; // HACİMLİ DATALARDA TAŞINABİLİR AMA BUNUN İÇİN FARKLI BİR YÖNTEMİMİZ VAR
            ViewData["names"] = new List<string>() { "EMİR", "ÖMER" };  // BUDA OBJECT OLRARK TAŞIR DİĞER TARAFA
            // YANİ OBJETC OLARAK VERİ ALIR

            TempData["surname"] = "yıldız";  // TEMP DATA BİR ACTİONDNA ÖBÜRÜNE VE FARKLI VİEWLERE VERİ TAŞIYABİLİR OBJECT OLARAK  AMA HACİMSEL VERİLERİ TAŞIRKEN SORUN ÇIKARIR BİR ACTİONDAN DİĞERİNE

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}