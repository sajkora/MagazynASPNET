using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Magazyn.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Magazyn.Context;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MagazynDbUserContextConnection") ?? throw new InvalidOperationException("Connection string 'MagazynDbUserContextConnection' not found.");

builder.Services.AddDbContext<MagazynDbUserContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MagazynUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<MagazynDbUserContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MagazynDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Items"));
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Identity/Account/Login";
    options.SlidingExpiration = true;
});

// Add this line to register session services
builder.Services.AddSession();

var app = builder.Build();

app.UseSession();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

