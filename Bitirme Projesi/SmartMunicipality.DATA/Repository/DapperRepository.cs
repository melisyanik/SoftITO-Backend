using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SmartMunicipality.DATA.IRepository;

namespace SmartMunicipality.DATA.Repository
{
    public class DapperRepository<T> : IDapperRepository<T> where T : class
    {
        private readonly string? _connectionString;

        public DapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<T>> QueryAsync(string sql, object? param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var db = CreateConnection())
            {
                return await db.QueryAsync<T>(sql, param, commandType: commandType);
            }
        }

        public async Task<T?> QueryFirstOrDefaultAsync(string sql, object? param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var db = CreateConnection())
            {
                return await db.QueryFirstOrDefaultAsync<T>(sql, param, commandType: commandType);
            }
        }

        public async Task<int> ExecuteAsync(string sql, object? param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var db = CreateConnection())
            {
                return await db.ExecuteAsync(sql, param, commandType: commandType);
            }
        }
    }
}
