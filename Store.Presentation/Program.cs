
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BL.DTOs;
using Store.DAL;
using Store.DAL.Identity;
using Store.Repositories.Brand;
using Store.Repositories.Category;
using Store.Repositories.Product;
using Store.Repositories.Wallet;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Memory Cache
builder.Services.AddMemoryCache();

// MeditR
builder.Services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(PhoneNumberDto).Assembly));

// User Secret
builder.Configuration.AddUserSecrets("0b8e2d76-24c1-40c7-936b-50781d320460");

// Add DbContext
string? connection = builder.Configuration.GetConnectionString("cnn");
builder.Services.AddDbContext<StoreDbContext>(x => x.UseSqlServer(connection));

// Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<StoreDbContext>();

// Add Repositories
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();

// Add Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy => policy.WithOrigins("https://localhost:44313")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
