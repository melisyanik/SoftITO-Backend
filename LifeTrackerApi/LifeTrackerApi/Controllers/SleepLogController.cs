using LifeTrackerApi.Data;
using LifeTrackerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LifeTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SleepLogController : ControllerBase
    {
        private readonly AppDbContext context;

        public SleepLogController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("GetSleepLogs")]
        public async Task<IEnumerable<SleepLog>> GetSleepLog()
        {
            return await context.SleepLogs.ToListAsync();
        }

        [HttpPost]
        [Route("AddSleepLog")]
        public async Task<SleepLog> AddSleepLog(SleepLog sleep)
        {
            context.SleepLogs.Add(sleep);
            await context.SaveChangesAsync();
            return sleep;
        }

        [HttpPut]
        [Route("UpdateSleepLog")]
        public async Task<SleepLog> UpdateSleepLog(SleepLog sleep)
        {
            context.Entry(sleep).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return sleep;
        }

        [HttpDelete]
        [Route("DeleteSleepLog/{id}")]
        public async Task<bool> DeleteSleepLog(int id)
        {
            var data = await context.SleepLogs.FindAsync(id);

            if (data == null)
                return false;

            context.SleepLogs.Remove(data);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
