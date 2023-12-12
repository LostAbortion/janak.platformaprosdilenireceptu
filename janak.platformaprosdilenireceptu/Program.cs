using djanak.Application.Abstraction;
using djanak.Application.Implementation;
using djanak.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using djanak.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MySql");  //propojení s databází 1
ServerVersion serverVersion = new MySqlServerVersion("8.0.34");  //propojení s databází 2

//Odtud potud Identity a roles
builder.Services.AddIdentity<User, Role>()
				.AddEntityFrameworkStores<EshopDbContext>()
				.AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequireDigit = false;
	options.Password.RequiredLength = 1;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
	options.Password.RequireLowercase = false;
	options.Password.RequiredUniqueChars = 1;
	options.Lockout.AllowedForNewUsers = true;
	options.Lockout.MaxFailedAccessAttempts = 10;
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
	options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
	options.LoginPath = "/Security/Account/Login";
	options.LogoutPath = "/Security/Account/Logout";
	options.SlidingExpiration = true;
});


builder.Services.AddScoped<IAccountService, AccountIdentityService>();
//Odtud potud Identity a roles

builder.Services.AddDbContext<EshopDbContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));  //propojení s databází 3

builder.Services.AddScoped<IFileUploadService, FileUploadService>
    (serviceProvider => new FileUploadService(serviceProvider.GetService<IWebHostEnvironment>().WebRootPath));

builder.Services.AddScoped<IProductAdminService, ProductAdminService>();//tento øádek propojuje moje interakce IProductAdminService s ProductAdminDFakeService
                                                                        //Pøepíšu to na ProductAdminService a tím to napojím místo fake na reálnou databázi
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
