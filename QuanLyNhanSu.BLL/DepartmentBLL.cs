using QuanLyNhanSu.DAL;
using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.BLL
{
    public class DepartmentBLL
    {
        private readonly DepartmentDAL _departmentDAL;

        public DepartmentBLL(DepartmentDAL departmentDAL)
        {
            _departmentDAL = departmentDAL;
        }

        public List<Department> GetAll() => _departmentDAL.GetAll();

        public Department? GetById(int id) => _departmentDAL.GetById(id);

        public (bool Success, string? Error) Create(Department dept)
        {
            if (string.IsNullOrWhiteSpace(dept.DeptName))
                return (false, "Tên phòng ban không được để trống.");

            _departmentDAL.Insert(dept);
            return (true, null);
        }

        public (bool Success, string? Error) Update(Department dept)
        {
            if (string.IsNullOrWhiteSpace(dept.DeptName))
                return (false, "Tên phòng ban không được để trống.");

            _departmentDAL.Update(dept);
            return (true, null);
        }

        public void Delete(int id) => _departmentDAL.Delete(id);
    }

}
