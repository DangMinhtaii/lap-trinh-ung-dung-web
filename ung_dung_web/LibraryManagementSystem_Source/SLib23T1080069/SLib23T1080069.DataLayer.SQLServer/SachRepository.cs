
using Microsoft.Data.SqlClient;
using SLib23T1080069.Models;
using SLib23T1080069.DataLayer.Interfaces;

namespace SLib23T1080069.DataLayer.SQLServer
{
    public class SachRepository : ISachRepository
    {
        private readonly KetNoiSQLServer _ketNoi;

        public SachRepository()
        {
            _ketNoi = new KetNoiSQLServer();
        }

        public async Task<List<Sach>> LayDanhSachSachAsync()
        {
            var danhSach = new List<Sach>();

            using SqlConnection ketNoi = _ketNoi.TaoKetNoi();
            await ketNoi.OpenAsync();

            string sql = @"
                SELECT BookId, ISBN, Title, Subtitle, PublisherId,
                       LanguageId, PublicationYear, Edition, Description,
                       PageCount, CoverImagePath, IsActive
                FROM Books";

            using SqlCommand lenh = new SqlCommand(sql, ketNoi);
            using SqlDataReader doc = await lenh.ExecuteReaderAsync();

            while (await doc.ReadAsync())
            {
                danhSach.Add(new Sach
                {
                    BookId = doc.GetInt32(doc.GetOrdinal("BookId")),
                    ISBN = doc.GetString(doc.GetOrdinal("ISBN")),
                    Title = doc.GetString(doc.GetOrdinal("Title")),
                    Subtitle = doc["Subtitle"] as string,
                    PublisherId = doc.GetInt32(doc.GetOrdinal("PublisherId")),
                    LanguageId = doc["LanguageId"] == DBNull.Value
                        ? null : Convert.ToInt32(doc["LanguageId"]),
                    PublicationYear = doc["PublicationYear"] == DBNull.Value
                        ? null : Convert.ToInt16(doc["PublicationYear"]),
                    Edition = doc["Edition"] as string,
                    Description = doc["Description"] as string,
                    PageCount = doc["PageCount"] == DBNull.Value
                        ? null : Convert.ToInt32(doc["PageCount"]),
                    CoverImagePath = doc["CoverImagePath"] as string,
                    IsActive = doc.GetBoolean(doc.GetOrdinal("IsActive"))
                });
            }

            return danhSach;
        }

        public async Task<Sach?> LaySachTheoMaAsync(int maSach)
        {
            var danhSach = await LayDanhSachSachAsync();

            return danhSach.FirstOrDefault(s => s.BookId == maSach);
        }
    }
}
