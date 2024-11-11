using EFCORE_VERÝALMA.Filters;
using EFCORE_VERÝALMA.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
    
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<NotFoundFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ROUTLAMA URL ÝSTEÐÝNÝ YÖNLENDÝRÝR 
app.MapControllerRoute( // EÞLEÞME PATTERN DE SAÐLANIR YANÝ anasayfa DÝYE BÝR ÝSTEK GELMELÝDÝR
    name: "Default",
    pattern: "anasayfa", // TAG HELPERS URL'Ý HTML RENDER EDÝLMEDEN ÖNCE ROUTE ÝLE KONTROL EDÝLÝP ÇEVRÝLÝR ÝSTEK YOLLANINCADA BURASI TETÝKLENÝR BÝR NEVÝ ÇÝFTE KONTROL
    defaults: new { controller = "Products", action = "Index" });

/*
app.MapControllerRoute(
    name: "getbyid",
    pattern: "{action}/{controller}/{productid?}"); // MANUEL ELLE GÝRÝLMELÝ O ZAMAN LÝNK
*/
/*
app.MapControllerRoute(
    name: "catchAll",
    pattern: "blog/{*article}", // ASTERÝKS KARAKTERÝ BLOGDAN SONRASINI KOMLE ALIR ARTÝCLA ATAR
    defaults: new { controller = "Blog", action = "Article" }); // DEAFULT EÐER ÜST TARAF UYARSA BUNU YAP DEMEK


app.MapControllerRoute("Default", "anasayfa", new { controller = "Home",action = "Index"});

app.MapControllerRoute(
    name: "default",
    pattern: "Home/Index/id?"); // SABÝR URL TANIMLAMSIDIR ÝDE DÝREKT HOME CONTROLLER OLARAK YORUMLAR
    
app.MapControllerRoute(
    name: "pages",
    pattern: "{controller}/{action}/{page}/{pageSize}"); // SÜSLÜ PARANTEZ ÝÇÝ DEÐÝÞKEN OLDUÐUNU GÖSTERÝR VE METHOD PARAMETRESÝYLE BUNLAR AYNI OLMAK ZORUNDADIR

app.MapControllerRoute(
    name: "default",
    pattern: "Home/Index/id?",
    defaults: new { controller = "Home", action = "Index" });
*/
/*
app.MapControllerRoute(
    name: "default1",
    pattern: "Home/Index/{id?}");
*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "getbyid",
    pattern: "{controller}/{action}/{productid}");


app.Run();
