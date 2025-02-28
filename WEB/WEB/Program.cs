using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WEB.Data;
using WEB.Reponsitory;
using WEB.ViewModels;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromSeconds(10);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<QuanLyBanHangContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("MOBILUX"))); 

var connectionString = builder.Configuration.GetConnectionString("QuanLyBanHangContext");
builder.Services.AddDbContext<QuanLyBanHangContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<ICategotyProductRepository, CategoryProductReposity>();


builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); //dang ky

builder.Services.AddAuthentication
	(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
	{
		options.LoginPath = "Account/Login";
		options.AccessDeniedPath = "/AccessDenied"; //đăng nhập mà chưa có quyền chuyển hướng đến
	});





//đăng ký
builder.Services.AddIdentity<AppUserVM, IdentityRole>()
	.AddEntityFrameworkStores<QuanLyBanHangContext>().AddDefaultTokenProviders();
builder.Services.AddRazorPages();


builder.Services.Configure<IdentityOptions>(options =>
{
	// Password settings.
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
	options.Password.RequiredLength = 4;

	// User settings.
	options.User.RequireUniqueEmail = false;


	options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
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

app.UseRouting();



app.UseAuthentication(); //phục hồi thông tin xác thực đăng nhập
app.UseAuthorization();
app.UseSession();//gio hang


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

