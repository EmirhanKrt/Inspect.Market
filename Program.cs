using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Inspect.Market.Context;
using Inspect.Market.Models;
using Inspect.Market.Services;
using Inspect.Market.Hubs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

/* Entity Framework */
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

/* ASP.NET'in saðladýðý Identity sisteminin kurulumu */
builder.Services
        .AddDefaultIdentity<ApplicationUser>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();

/* 
 * Access Denied ve Redirect To Login aksiyonlarýnda 
 * kullanýcýnýn yönlendirileceði sayfalarýn konfigürasyonu
*/
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events = new CookieAuthenticationEvents
    {
        OnRedirectToAccessDenied = context =>
        {
            context.Response.Redirect("/");
            return Task.CompletedTask;
        },
        OnRedirectToLogin = context =>
        {
            context.Response.Redirect("/Auth/Login");
            return Task.CompletedTask;
        }
    };
});

builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddRazorPages();

/* 
 * Veri güncellemesini yakalayan BackgroundService ve
 * Veri güncellemesini kullanýcýlara ileten WebSocket konfigürasyonu
*/
builder.Services.AddHttpClient();
builder.Services.AddSingleton<MarketDataService>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<MarketDataService>());
builder.Services.AddSignalR();

var app = builder.Build();

/* 
 * Uygulama baþlarken "initial" verilerin Binance borsasýndan çekilmesini bekleyen blok.
*/
using (var scope = app.Services.CreateScope())
{
    var marketDataService = scope.ServiceProvider.GetRequiredService<MarketDataService>();
    var cancellationToken = new CancellationTokenSource().Token;
    marketDataService.InitializeMarketData(cancellationToken).GetAwaiter().GetResult();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

/* 
 * Kullanýcýlar /Auth altýnda farklý sayfalara girdiði zaman 
 * Kullanýcýyý default olarak /Auth/Login sayfasýna yönlendiren middleware.
*/
app.Use(async (context, next) =>
{
    var path = context.Request.Path.ToString().ToLower();
    var user = context.User;

    if (path.StartsWith("/auth") && path != "/auth/login" && path != "/auth/register" && (path == "/auth/logout" && context.Request.Method == "GET"))
    {
        context.Response.Redirect("/Auth/Login");
        return;
    }

    if ((path == "/auth/login" || path == "/auth/register") && user.Identity.IsAuthenticated)
    {
        context.Response.Redirect("/");
        return;
    }

    if (path == "/auth/logout" && !user.Identity.IsAuthenticated && context.Request.Method == "POST")
    {
        context.Response.Redirect("/");
        return;
    }

    await next.Invoke();
});

app.MapControllerRoute(
    name: "cryptocurrency",
    pattern: "cryptocurrency/{cryptocurrencySlug}",
    defaults: new { controller = "Cryptocurrency", action = "Details" }
);

app.MapAreaControllerRoute(
    name: "api",
    areaName: "Api",
    pattern: "api/{controller=Home}/{action=Index}/{id?}"
);

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();

/* 
 * WebSocket uzantýsý konfigürasyonu
*/
app.MapHub<MarketDataHub>("/marketDataHub");

app.Run();