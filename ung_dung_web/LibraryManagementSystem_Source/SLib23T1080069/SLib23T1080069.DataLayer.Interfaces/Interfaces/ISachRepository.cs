
using SLib23T1080069.Models;

namespace SLib23T1080069.DataLayer.Interfaces
{
    public interface ISachRepository
    {
        Task<List<Sach>> LayDanhSachSachAsync();

        Task<Sach?> LaySachTheoMaAsync(int maSach); 
    }
}
