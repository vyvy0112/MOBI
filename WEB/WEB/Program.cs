using Microsoft.EntityFrameworkCore;
using WEB.Data;
using WEB.Reponsitory;

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

var app = builder.Build();


//đăng ký session dành cho giỏ hàng
//app.UseSession();






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
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
