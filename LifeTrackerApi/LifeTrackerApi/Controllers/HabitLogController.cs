using LifeTrackerApi.Data;
using LifeTrackerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LifeTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class HabitLogController : ControllerBase
        {
            private readonly AppDbContext context;

            public HabitLogController(AppDbContext context)
            {
                this.context = context;
            }

            [HttpGet]
            [Route("GetHabitLogs")]
            public async Task<IEnumerable<HabitLog>> GetHabitLog()
            {
                return await context.HabitLogs.ToListAsync();
            }

            [HttpPost]
            [Route("AddHabitLog")]
            public async Task<HabitLog> AddHabitLog(HabitLog habit)
            {
                context.HabitLogs.Add(habit);
                await context.SaveChangesAsync();
                return habit;
            }

            [HttpPut]
            [Route("UpdateHabitLog")]
            public async Task<HabitLog> UpdateHabitLog(HabitLog habit)
            {
                context.Entry(habit).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return habit;
            }

            [HttpDelete]
            [Route("DeleteHabitLog/{id}")]
            public async Task<bool> DeleteHabitLog(int id)
            {
                var data = await context.HabitLogs.FindAsync(id);

                if (data == null)
                    return false;

                context.HabitLogs.Remove(data);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
