
using Dapper;
using SLib.DataLayer.Interfaces;

namespace SLib.DataLayer.SQLServer
{
    public class DapperRepository<T> : IRepository<T> where T : class
    {
        private readonly DbHelper _dbHelper;

        public DapperRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            var map = EntitySqlMap.For<T>();

            using var connection = _dbHelper.GetConnection();

            return await connection.QueryAsync<T>(map.ListSql);
        }

        public async Task<T?> GetAsync(int id)
        {
            var map = EntitySqlMap.For<T>();

            using var connection = _dbHelper.GetConnection();

            return await connection.QueryFirstOrDefaultAsync<T>(
                map.GetSql, new { Id = id });
        }

        public async Task<int> AddAsync(T entity)
        {
            var map = EntitySqlMap.For<T>();

            using var connection = _dbHelper.GetConnection();

            return await connection.QuerySingleAsync<int>(
                map.AddSql, entity);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var map = EntitySqlMap.For<T>();

            using var connection = _dbHelper.GetConnection();

            int rows = await connection.ExecuteAsync(
                map.UpdateSql, entity);

            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var map = EntitySqlMap.For<T>();

            using var connection = _dbHelper.GetConnection();

            int rows = await connection.ExecuteAsync(
                map.DeleteSql, new { Id = id });

            return rows > 0;
        }

        public async Task<bool> InUseAsync(int id)
        {
            var map = EntitySqlMap.For<T>();

            using var connection = _dbHelper.GetConnection();

            int result = await connection.ExecuteScalarAsync<int>(
                map.InUseSql, new { Id = id });

            return result == 1;
        }
    }
}
