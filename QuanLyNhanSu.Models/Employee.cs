using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
        public int DeptId { get; set; }

        // Không có trong bảng Employee, chỉ dùng để hiển thị tên phòng ban
        // sau khi JOIN với bảng Department — tiện cho việc hiển thị ở View.
        public string? DeptName { get; set; }
    }

}
