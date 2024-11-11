var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();  // USER KULLANICIDIR CL�ENT �STEK OLU�TURAN ARA�TIR �P HER C�HAZA VER�LEN �ZEL K�ML�KLERD�R DOMA�NLER �SE BU �P LERE Y�NLEND�RME YAPAN �S�MLERD�R  www.google.com B�R DOMA�ND�R BU �P YE �EVR�L�P �LG�L� SUNUCUYA BA�LANIR SERVER/SUNUCU/HOST�NG WEB S�TELER�N� 7/24 BARINDIRAN YERLERD�R 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();  // �STEK CONTROLLERA GEL�R O VER� GEREK�YORSA MODEL KISMINI TET�KLER VER� GEL�R V�EWE �HT�YA� VARSA V�EWE G�NDER�R BU HTML LE KAPLANIR RENDER ED�L�R YAN� TARAYICININ OKUYAB�LECE�� D�LE YAN�
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");// DEFAULT OLARAK HOME/INDEX TET�KLEN�R
                 // IDE HOMECONTROLLER ARAR CONTROLLER EK�YLE ONUN KONTROLLER OLDU�U ANLA�ILIR
app.Run();
