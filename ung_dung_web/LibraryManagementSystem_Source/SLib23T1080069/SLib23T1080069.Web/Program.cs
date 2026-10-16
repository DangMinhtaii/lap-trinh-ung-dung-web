
using SLib.DataLayer.Interfaces;
using SLib.DataLayer.SQLServer;
using SLib.BusinessLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký dịch vụ MVC.
builder.Services.AddControllersWithViews();

// Đăng ký kết nối SQL Server.
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Không tìm thấy chuỗi kết nối DefaultConnection.");

builder.Services.AddSingleton(new DbHelper(connectionString));

// Đăng ký Repository dùng chung.
builder.Services.AddScoped(typeof(IRepository<>), typeof(DapperRepository<>));
builder.Services.AddScoped(typeof(GenericService<>));

var app = builder.Build();

// Cấu hình xử lý yêu cầu HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
