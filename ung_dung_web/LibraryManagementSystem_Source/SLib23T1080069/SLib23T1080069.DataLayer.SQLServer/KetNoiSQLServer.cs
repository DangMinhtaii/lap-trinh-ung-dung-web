
using Microsoft.Data.SqlClient;

namespace SLib23T1080069.DataLayer.SQLServer
{
    public class KetNoiSQLServer
    {
        private readonly string chuoiKetNoi =
            @"Server=DESKTOP-K8NNM7B;Database=LibraryManagementDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Tao doi tuong ket noi SQL Server
        public SqlConnection TaoKetNoi()
        {
            return new SqlConnection(chuoiKetNoi);
        }

        // Kiem tra ket noi SQL Server
        public async Task<bool> KiemTraKetNoiAsync()
        {
            try
            {
                using SqlConnection ketNoi = TaoKetNoi();

                await ketNoi.OpenAsync();

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}
