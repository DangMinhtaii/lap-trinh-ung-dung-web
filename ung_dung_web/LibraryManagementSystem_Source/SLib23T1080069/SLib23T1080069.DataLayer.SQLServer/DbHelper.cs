
using Microsoft.Data.SqlClient;

namespace SLib.DataLayer.SQLServer
{
    /// <summary>
    /// Hỗ trợ tạo kết nối đến cơ sở dữ liệu SQL Server.
    /// </summary>
    public class DbHelper
    {
        private readonly string _connectionString;

        /// <summary>
        /// Khởi tạo DbHelper bằng chuỗi kết nối.
        /// </summary>
        /// <param name="connectionString">
        /// Chuỗi kết nối đến cơ sở dữ liệu.
        /// </param>
        public DbHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Tạo kết nối mới đến SQL Server.
        /// </summary>
        /// <returns>Kết nối SQL Server.</returns>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
