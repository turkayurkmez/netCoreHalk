using eshop.Application;
using eshop.DataAccess.Data;
using eshop.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, EFProductRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
builder.Services.AddSingleton<IUserService, UserService>();

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<ShopDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Accounts/Login";
                    option.AccessDeniedPath = "/Accounts/AccessDenied";

                });

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
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    //Sayfa3




    //endpoints.MapControllerRoute(
    //    name: "category",
    //    pattern: "{categoryId?}/Sayfa{pageNo}",
    //    defaults: new { controller = "Home", action = "Index", pageNo = 1 }
    //    );


    endpoints.MapControllerRoute(
        name: "paging",
        pattern: "Sayfa{pageNo}",
        defaults: new { controller = "Home", action = "Index", pageNo = 1 }
        );


    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
