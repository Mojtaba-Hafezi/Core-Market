using CoreMarket.Data;
using CoreMarket.Interfaces;
using CoreMarket.ServiceContracts;
using CoreMarket.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
var connectionString = builder.Configuration.GetConnectionString("CoreMarketConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBrandService, BrandService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
