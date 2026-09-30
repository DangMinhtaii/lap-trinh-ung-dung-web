using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLyNhanSu.BLL;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeBLL _employeeBLL;
        private readonly DepartmentBLL _departmentBLL;

        public EmployeeController(EmployeeBLL employeeBLL, DepartmentBLL departmentBLL)
        {
            _employeeBLL = employeeBLL;
            _departmentBLL = departmentBLL;
        }

        public IActionResult Index()
        {
            var list = _employeeBLL.GetAll();
            return View(list);
        }

        // Trả về danh sách phòng ban để đổ vào thẻ <select>, có thể chọn sẵn 1 mục.
        private SelectList DepartmentOptions(int? selectedId = null)
        {
            var departments = _departmentBLL.GetAll();
            return new SelectList(departments, "DeptId", "DeptName", selectedId);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = DepartmentOptions();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            var (success, error) = _employeeBLL.Create(emp);
            if (!success)
            {
                ModelState.AddModelError("", error!);
                ViewBag.Departments = DepartmentOptions(emp.DeptId);
                return View(emp);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = _employeeBLL.GetById(id);
            if (emp == null) return NotFound();

            ViewBag.Departments = DepartmentOptions(emp.DeptId);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            var (success, error) = _employeeBLL.Update(emp);
            if (!success)
            {
                ModelState.AddModelError("", error!);
                ViewBag.Departments = DepartmentOptions(emp.DeptId);
                return View(emp);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var emp = _employeeBLL.GetById(id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }

}
