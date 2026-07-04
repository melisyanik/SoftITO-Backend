using Dapper;
using PetCareTrackerMVC.Data;
using System.Data;

namespace PetCareTrackerMVC.Repositories
{
    public class BaseRepository
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        protected IDbConnection Connection => _context.CreateConnection();

        public async Task<int> Execute(string sp, object? param = null)
        {
            using var conn = Connection;
            return await conn.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> Query<T>(string sp, object? param = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            using var conn = Connection;
            return await conn.QueryAsync<T>(sp, param, commandType: cmdType);
        }

        public async Task<T?> QueryFirstOrDefault<T>(string sp, object? param = null)
        {
            using var conn = Connection;
            return await conn.QueryFirstOrDefaultAsync<T>(sp, param, commandType: CommandType.StoredProcedure);
        }
    }
}
