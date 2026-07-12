using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace SmartMunicipality.DapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly string _connectionString;

        public ReportsController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? "Server=(localdb)\\MSSQLLocalDB;Database=SmartMunicipalityDb;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        private SqlConnection CreateConnection() => new SqlConnection(_connectionString);

        
        [HttpGet("DashboardStats")]
        public async Task<IActionResult> GetDashboardStats()
        {
            using (var conn = CreateConnection())
            {
                var stats = await conn.QuerySingleOrDefaultAsync<dynamic>(
                    "sp_GetDashboardStats", 
                    commandType: CommandType.StoredProcedure
                );
                if (stats == null) return NotFound();
                return Ok((IDictionary<string, object>)stats);
            }
        }

        
        [HttpGet("ComplaintsByCategory")]
        public async Task<IActionResult> GetComplaintsByCategory()
        {
            using (var conn = CreateConnection())
            {
                var result = await conn.QueryAsync(
                    "sp_GetComplaintsByCategory", 
                    commandType: CommandType.StoredProcedure
                );
                var dictResult = result.Select(r => (IDictionary<string, object>)r).ToList();
                return Ok(dictResult);
            }
        }

        
        [HttpGet("ComplaintsByDistrict")]
        public async Task<IActionResult> GetComplaintsByDistrict()
        {
            using (var conn = CreateConnection())
            {
                var result = await conn.QueryAsync(
                    "sp_GetComplaintsByDistrict", 
                    commandType: CommandType.StoredProcedure
                );
                var dictResult = result.Select(r => (IDictionary<string, object>)r).ToList();
                return Ok(dictResult);
            }
        }

        
        [HttpGet("MonthlyRevenue")]
        public async Task<IActionResult> GetMonthlyRevenue()
        {
            using (var conn = CreateConnection())
            {
                var result = await conn.QueryAsync(
                    "sp_GetMonthlyRevenue", 
                    commandType: CommandType.StoredProcedure
                );
                var dictResult = result.Select(r => (IDictionary<string, object>)r).ToList();
                return Ok(dictResult);
            }
        }

        
        [HttpGet("YearlyRevenue")]
        public async Task<IActionResult> GetYearlyRevenue()
        {
            using (var conn = CreateConnection())
            {
                var result = await conn.QueryAsync(
                    "sp_GetYearlyRevenue", 
                    commandType: CommandType.StoredProcedure
                );
                var dictResult = result.Select(r => (IDictionary<string, object>)r).ToList();
                return Ok(dictResult);
            }
        }

        
        [HttpGet("HeatMapData")]
        public async Task<IActionResult> GetHeatMapData()
        {
            using (var conn = CreateConnection())
            {
                var result = await conn.QueryAsync(
                    "sp_GetHeatMapData", 
                    commandType: CommandType.StoredProcedure
                );
                var dictResult = result.Select(r => (IDictionary<string, object>)r).ToList();
                return Ok(dictResult);
            }
        }
        
        [HttpGet("ComplaintsByStatus")]
        public async Task<IActionResult> GetComplaintsByStatus()
        {
            using (var conn = CreateConnection())
            {
                var result = await conn.QueryAsync(
                    "sp_GetComplaintsByStatus",
                    commandType: CommandType.StoredProcedure
                );
                var dictResult = result.Select(r => (IDictionary<string, object>)r).ToList();
                return Ok(dictResult);
            }
        }
    }
}
