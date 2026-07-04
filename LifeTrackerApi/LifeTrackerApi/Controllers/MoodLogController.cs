using LifeTrackerApi.Data;
using LifeTrackerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LifeTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoodLogController : ControllerBase
    {
        private readonly AppDbContext context;

        public MoodLogController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("GetMoodLogs")]
        public async Task<IEnumerable<MoodLog>> GetMoodLog()
        {
            return await context.MoodLogs.ToListAsync();
        }

        [HttpPost]
        [Route("AddMoodLog")]
        public async Task<MoodLog> AddMoodLog(MoodLog mood)
        {
            context.MoodLogs.Add(mood);
            await context.SaveChangesAsync();
            return mood;
        }

        [HttpPut]
        [Route("UpdateMoodLog")]
        public async Task<MoodLog> UpdateMoodLog(MoodLog mood)
        {
            context.Entry(mood).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return mood;
        }

        [HttpDelete]
        [Route("DeleteMoodLog/{id}")]
        public async Task<bool> DeleteMoodLog(int id)
        {
            var data = await context.MoodLogs.FindAsync(id);

            if (data == null)
                return false;

            context.MoodLogs.Remove(data);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
