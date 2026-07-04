using System.Data;
using Microsoft.Data.SqlClient;

namespace PetCareTrackerMVC.Data
{
    public class AppDbContext
    {
        private readonly string _connectionString;

        public AppDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' is not configured.");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
