using Microsoft.Data.SqlClient;
using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DAL
{
    public class EmployeeDAL
    {
        private readonly DbHelper _dbHelper;

        public EmployeeDAL(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        private const string SelectColumns = @"
            SELECT e.EmpId, e.FirstName, e.LastName, e.Gender,
                   e.Birthday, e.Address, e.DeptId, d.DeptName
            FROM Employee e
            JOIN Department d ON e.DeptId = d.DeptId";

        public List<Employee> GetAll()
        {
            var list = new List<Employee>();
            using var conn = _dbHelper.GetConnection();
            using var cmd = new SqlCommand(SelectColumns + " ORDER BY e.EmpId", conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(Map(reader));
            return list;
        }

        public Employee? GetById(int id)
        {
            using var conn = _dbHelper.GetConnection();
            var sql = SelectColumns + " WHERE e.EmpId = @Id";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? Map(reader) : null;
        }

        public void Insert(Employee emp)
        {
            using var conn = _dbHelper.GetConnection();
            var sql = @"INSERT INTO Employee
                            (FirstName, LastName, Gender,
                             Birthday, Address, DeptId)
                        VALUES
                            (@FirstName, @LastName, @Gender,
                             @Birthday, @Address, @DeptId)";
            using var cmd = new SqlCommand(sql, conn);
            AddParameters(cmd, emp);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Update(Employee emp)
        {
            using var conn = _dbHelper.GetConnection();
            var sql = @"UPDATE Employee SET
                            FirstName = @FirstName,
                            LastName = @LastName,
                            Gender = @Gender,
                            Birthday = @Birthday,
                            Address = @Address,
                            DeptId = @DeptId
                        WHERE EmpId = @EmpId";
            using var cmd = new SqlCommand(sql, conn);
            AddParameters(cmd, emp);
            cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = _dbHelper.GetConnection();
            var sql = "DELETE FROM Employee WHERE EmpId = @Id";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private static void AddParameters(SqlCommand cmd, Employee emp)
        {
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@Gender", (object?)emp.Gender ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Birthday",
                (object?)emp.Birthday ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Address",
                (object?)emp.Address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DeptId", emp.DeptId);
        }

        private static Employee Map(SqlDataReader reader) => new Employee
        {
            EmpId = reader.GetInt32(0),
            FirstName = reader.GetString(1),
            LastName = reader.GetString(2),
            Gender = reader.IsDBNull(3) ? null : reader.GetString(3),
            Birthday = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
            Address = reader.IsDBNull(5) ? null : reader.GetString(5),
            DeptId = reader.GetInt32(6),
            DeptName = reader.GetString(7)
        };
    }

}
