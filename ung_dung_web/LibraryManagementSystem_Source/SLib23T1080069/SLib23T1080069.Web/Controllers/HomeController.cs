
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using SLib23T1080069.Web.Models;
using SLib.DataLayer.SQLServer;

namespace SLib23T1080069.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbHelper _dbHelper;

        public HomeController(
            ILogger<HomeController> logger,
            DbHelper dbHelper)
        {
            _logger = logger;
            _dbHelper = dbHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Kiểm tra kết nối và truy vấn cơ sở dữ liệu.
        public async Task<IActionResult> TestDatabase()
        {
            try
            {
                using var connection = _dbHelper.GetConnection();

                await connection.OpenAsync();

                string databaseName = await connection.QuerySingleAsync<string>(
                    "SELECT DB_NAME()");

                return Content(
                    $"Kết nối SQL Server thành công! Cơ sở dữ liệu: {databaseName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi kiểm tra kết nối SQL Server.");

                return StatusCode(
                    500,
                    "Không thể kết nối cơ sở dữ liệu. " +
                    "Hãy kiểm tra chuỗi kết nối và nhật ký lỗi.");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
