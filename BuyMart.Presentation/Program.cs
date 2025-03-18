using BuyMart.BLL.Interfaces;
using BuyMart.BLL;
using BuyMart.Data;
using Microsoft.EntityFrameworkCore;
using BuyMart.Data.Repositories.IRepository;
using BuyMart.Data.Repositories;
using BuyMart.Bll.Interfaces;
using BuyMart.Bll.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDataLayerServices(builder.Configuration);

builder.Services.AddScoped<IUnitOfWork, UnitOfwork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<ICategoryBLL, CategoryBLL>();
builder.Services.AddScoped<IProductBLL, ProductBLL>();
builder.Services.AddScoped<ICartBll, CartBll>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddRazorPages(); // This is required for Identity UI to work


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.MapRazorPages();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
