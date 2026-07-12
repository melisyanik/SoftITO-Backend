using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SmartMunicipality.DATA.IRepository
{
    public interface IDapperRepository<T> where T : class
    {
        Task<IEnumerable<T>> QueryAsync(string sql, object? param = null, CommandType commandType = CommandType.StoredProcedure);
        Task<T?> QueryFirstOrDefaultAsync(string sql, object? param = null, CommandType commandType = CommandType.StoredProcedure);
        Task<int> ExecuteAsync(string sql, object? param = null, CommandType commandType = CommandType.StoredProcedure);
    }
}
