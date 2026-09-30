using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DAL
{
    public class DbHelper
    {
        private readonly string _connectionString;

        public DbHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public SqlConnection GetConnection() => new SqlConnection(_connectionString);
    }

}
