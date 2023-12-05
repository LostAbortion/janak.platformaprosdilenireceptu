using djanak.Application.Abstraction;
using djanak.Application.Implementation;
using djanak.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MySql");  //propojení s databází 1
ServerVersion serverVersion = new MySqlServerVersion("8.0.34");  //propojení s databází 2

builder.Services.AddDbContext<EshopDbContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));  //propojení s databází 3

builder.Services.AddScoped<IFileUploadService, FileUploadService>
    (serviceProvider => new FileUploadService(serviceProvider.GetService<IWebHostEnvironment>().WebRootPath));

builder.Services.AddScoped<IProductAdminService, ProductAdminDFakeService>();
builder.Services.AddScoped<IHomeService, HomeService>();

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

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
