var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();  // USER KULLANICIDIR CLÝENT ÝSTEK OLUÞTURAN ARAÇTIR ÝP HER CÝHAZA VERÝLEN ÖZEL KÝMLÝKLERDÝR DOMAÝNLER ÝSE BU ÝP LERE YÖNLENDÝRME YAPAN ÝSÝMLERDÝR  www.google.com BÝR DOMAÝNDÝR BU ÝP YE ÇEVRÝLÝP ÝLGÝLÝ SUNUCUYA BAÐLANIR SERVER/SUNUCU/HOSTÝNG WEB SÝTELERÝNÝ 7/24 BARINDIRAN YERLERDÝR 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();  // ÝSTEK CONTROLLERA GELÝR O VERÝ GEREKÝYORSA MODEL KISMINI TETÝKLER VERÝ GELÝR VÝEWE ÝHTÝYAÇ VARSA VÝEWE GÖNDERÝR BU HTML LE KAPLANIR RENDER EDÝLÝR YANÝ TARAYICININ OKUYABÝLECEÐÝ DÝLE YANÝ
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");// DEFAULT OLARAK HOME/INDEX TETÝKLENÝR
                 // IDE HOMECONTROLLER ARAR CONTROLLER EKÝYLE ONUN KONTROLLER OLDUÐU ANLAÞILIR
app.Run();
