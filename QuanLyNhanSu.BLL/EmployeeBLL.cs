using QuanLyNhanSu.DAL;
using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.BLL
{
    public class EmployeeBLL
    {
        private readonly EmployeeDAL _employeeDAL;

        public EmployeeBLL(EmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        public List<Employee> GetAll() => _employeeDAL.GetAll();

        public Employee? GetById(int id) => _employeeDAL.GetById(id);

        public (bool Success, string? Error) Create(Employee emp)
        {
            bool noName = string.IsNullOrWhiteSpace(emp.FirstName)
                       || string.IsNullOrWhiteSpace(emp.LastName);
            if (noName)
                return (false, "Họ và tên không được để trống.");
            if (emp.DeptId <= 0)
                return (false, "Vui lòng chọn phòng ban.");

            _employeeDAL.Insert(emp);
            return (true, null);
        }

        public (bool Success, string? Error) Update(Employee emp)
        {
            bool noName = string.IsNullOrWhiteSpace(emp.FirstName)
                       || string.IsNullOrWhiteSpace(emp.LastName);
            if (noName)
                return (false, "Họ và tên không được để trống.");

            _employeeDAL.Update(emp);
            return (true, null);
        }

        public void Delete(int id) => _employeeDAL.Delete(id);
    }

}
