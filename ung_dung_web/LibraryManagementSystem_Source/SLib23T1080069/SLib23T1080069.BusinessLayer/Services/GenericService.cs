
using SLib.DataLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SLib.BusinessLayer.Services
{
    public class GenericService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(
                    "ID phải lớn hơn 0.");
            }

            return await _repository.GetAsync(id);
        }

        public async Task<int> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(int id, T entity)
        {
            if (id <= 0)
            {
                throw new ArgumentException(
                    "ID phải lớn hơn 0.");
            }

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(
                    "ID phải lớn hơn 0.");
            }

            if (await _repository.InUseAsync(id))
            {
                throw new InvalidOperationException(
                    "Không thể xóa vì dữ liệu đang được sử dụng.");
            }

            return await _repository.DeleteAsync(id);
        }
    }
}
