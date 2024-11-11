using EFCORE_VER�ALMA.Filters;
using EFCORE_VER�ALMA.Models;
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

// ROUTLAMA URL �STE��N� Y�NLEND�R�R 
app.MapControllerRoute( // E�LE�ME PATTERN DE SA�LANIR YAN� anasayfa D�YE B�R �STEK GELMEL�D�R
    name: "Default",
    pattern: "anasayfa", // TAG HELPERS URL'� HTML RENDER ED�LMEDEN �NCE ROUTE �LE KONTROL ED�L�P �EVR�L�R �STEK YOLLANINCADA BURASI TET�KLEN�R B�R NEV� ��FTE KONTROL
    defaults: new { controller = "Products", action = "Index" });

/*
app.MapControllerRoute(
    name: "getbyid",
    pattern: "{action}/{controller}/{productid?}"); // MANUEL ELLE G�R�LMEL� O ZAMAN L�NK
*/
/*
app.MapControllerRoute(
    name: "catchAll",
    pattern: "blog/{*article}", // ASTER�KS KARAKTER� BLOGDAN SONRASINI KOMLE ALIR ART�CLA ATAR
    defaults: new { controller = "Blog", action = "Article" }); // DEAFULT E�ER �ST TARAF UYARSA BUNU YAP DEMEK


app.MapControllerRoute("Default", "anasayfa", new { controller = "Home",action = "Index"});

app.MapControllerRoute(
    name: "default",
    pattern: "Home/Index/id?"); // SAB�R URL TANIMLAMSIDIR �DE D�REKT HOME CONTROLLER OLARAK YORUMLAR
    
app.MapControllerRoute(
    name: "pages",
    pattern: "{controller}/{action}/{page}/{pageSize}"); // S�SL� PARANTEZ ��� DE���KEN OLDU�UNU G�STER�R VE METHOD PARAMETRES�YLE BUNLAR AYNI OLMAK ZORUNDADIR

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
