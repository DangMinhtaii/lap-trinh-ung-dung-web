
using Microsoft.AspNetCore.Mvc;
using SLib.BusinessLayer.Services;
using SLib.Models.Entities;

namespace SLib23T1080069.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly GenericService<Book> _bookService;

        public BooksController(GenericService<Book> bookService)
        {
            _bookService = bookService;
        }

        // Hiển thị danh sách sách
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();
            return View(books);
        }

        // Hiển thị form thêm sách
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Book { IsActive = true });
        }

        // Lưu sách mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book sach)
        {
            if (!ModelState.IsValid)
            {
                return View(sach);
            }

            try
            {
                sach.CreatedAt = DateTime.Now;
                int id = await _bookService.AddAsync(sach);

                TempData["Success"] = $"Đã thêm sách thành công. Mã sách: {id}";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Không thể thêm sách. Hãy kiểm tra ISBN có bị trùng hoặc dữ liệu nhập có hợp lệ không.");
                return View(sach);
            }
        }

        // Hiển thị form sửa sách
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var sach = await _bookService.GetByIdAsync(id);

            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // Lưu thay đổi sách
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book sach)
        {
            if (id != sach.BookId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(sach);
            }

            try
            {
                bool updated = await _bookService.UpdateAsync(id, sach);

                if (!updated)
                {
                    return NotFound();
                }

                TempData["Success"] = "Đã cập nhật thông tin sách.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Không thể cập nhật sách. Hãy kiểm tra ISBN có bị trùng hoặc dữ liệu nhập có hợp lệ không.");
                return View(sach);
            }
        }

        // Xác nhận trước khi xóa
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var sach = await _bookService.GetByIdAsync(id);

            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // Thực hiện xóa sách
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                bool deleted = await _bookService.DeleteAsync(id);

                if (!deleted)
                {
                    return NotFound();
                }

                TempData["Success"] = "Đã xóa sách thành công.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (Exception)
            {
                TempData["Error"] = "Không thể xóa sách. Sách có thể đang được sử dụng.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
