using Infrastructure;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Service;
using Microsoft.AspNetCore.Identity;
using Model.Entities;
using System.Security.Claims;
using Infrastructure.RepositoryClasses;
using Infrastructure.RepositoryInterfaces;
using Service.ServiceInterfaces;
using Service.ServiceClasses;
//var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("OnlineTicketDbContextConnection") ?? throw new InvalidOperationException("Connection string 'OnlineTicketDbContextConnection' not found.");

//builder.Services.AddDbContext<OnlineTicketDbContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<OnlineTicketDbContext>();

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();



var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("OnlineTicketDbContextConnection") ?? throw new InvalidOperationException("Connection string 'OnlineTicketDbContextConnection' not found.");

TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
MapsterConfig.RegisterMapping();

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
//builder.Services.AddControllersWithViews(option =>
//{
//    //option.Filters.Add<>();
//});

builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<OnlineTicketDbContext>().AddDefaultTokenProviders().AddDefaultUI();


//builder.Services.AddIdentity<User, Role>(
//options =>
//{
//    options.SignIn.RequireConfirmedAccount = true;
//}).AddEntityFrameworkStores<OnlineTicketDbContext>().AddDefaultTokenProviders();


builder.Services.AddDbContext<DbContext, OnlineTicketDbContext>();
builder.Services.AddScoped<ClaimsPrincipal>();

builder.Services.ConfigureApplicationCookie(option =>
{
    //option.LoginPath = "/Identity/Account/Login";
});
// Add services to the container.

//builder.Services.AddDefaultIdentity<IdentityUser>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = true;
//    options.User.RequireUniqueEmail = true;
//    options.Password.RequireDigit = true;
//    options.Password.RequiredLength = 10;
//}).AddEntityFrameworkStores<OnlineTicketDbContext>();
builder.Services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.AddAuthentication();
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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
         name: "default",
         pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();