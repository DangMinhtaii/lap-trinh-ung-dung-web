using Microsoft.Data.SqlClient;
using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DAL
{
    public class DepartmentDAL
    {
        private readonly DbHelper _dbHelper;

        public DepartmentDAL(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<Department> GetAll()
        {
            var list = new List<Department>();
            using var conn = _dbHelper.GetConnection();
            using var cmd = new SqlCommand(
                "SELECT DeptId, DeptName FROM Department ORDER BY DeptName", conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Department
                {
                    DeptId = reader.GetInt32(0),
                    DeptName = reader.GetString(1)
                });
            }
            return list;
        }

        public Department? GetById(int id)
        {
            using var conn = _dbHelper.GetConnection();
            using var cmd = new SqlCommand(
                "SELECT DeptId, DeptName FROM Department WHERE DeptId = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Department
                {
                    DeptId = reader.GetInt32(0),
                    DeptName = reader.GetString(1)
                };
            }
            return null;
        }

        public void Insert(Department dept)
        {
            using var conn = _dbHelper.GetConnection();
            using var cmd = new SqlCommand(
                "INSERT INTO Department (DeptName) VALUES (@DeptName)", conn);
            cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Update(Department dept)
        {
            using var conn = _dbHelper.GetConnection();
            var sql = "UPDATE Department SET DeptName = @DeptName " +
                      "WHERE DeptId = @DeptId";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);
            cmd.Parameters.AddWithValue("@DeptId", dept.DeptId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = _dbHelper.GetConnection();
            var sql = "DELETE FROM Department WHERE DeptId = @Id";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

}
