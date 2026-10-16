
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SLib.DataLayer.Interfaces
{
    /// <summary>
    /// Định nghĩa các thao tác dữ liệu dùng chung.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListAsync();

        Task<T?> GetAsync(int id);

        Task<int> AddAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);

        Task<bool> InUseAsync(int id);
    }
}
