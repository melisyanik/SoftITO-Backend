using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AstroComment.Data
{
    public class Context
    {
        public static string connectionString =
            @"Server=localhost\SQLEXPRESS;Database=BurcYorumlamaDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static IEnumerable<T> Query<T>(string procName, DynamicParameters param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<T>(procName, param, commandType: commandType);
            }
        }

        public static void Execute(string procName, DynamicParameters param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Execute(procName, param, commandType: commandType);
            }
        }
    }
}
