
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BL.DTOs;
using Store.DAL;
using Store.DAL.Identity;
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

// Add DbContext
builder.Services.AddDbContext<StoreDbContext>(x => x.UseSqlServer("Server=.;Database=HardwareStore;User ID=sa; Trust Server Certificate=true; Password=ilia.1384;"));

// Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<StoreDbContext>();

// Add Repositories
builder.Services.AddScoped<IWalletRepository, WalletRepository>();

// Add Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy => policy.WithOrigins("http://127.0.0.1:5500")
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
