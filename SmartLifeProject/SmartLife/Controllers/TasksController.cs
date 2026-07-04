using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartLife.Api.Data;
using SmartLife.Models;
using System.Security.Claims;

namespace SmartLife.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext dbcontext;

        public TasksController(AppDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        [HttpGet]
        [Route("GetTasks")]
        public async Task<IEnumerable<Tasks>> GetTasks()
        {
            return await dbcontext.Tasks
                .Where(x => x.UserId == CurrentUserId)
                .ToListAsync();
        }

        [HttpGet]
        [Route("GetTasksById/{id}")]
        public async Task<ActionResult<Tasks>> GetTasksById(int id)
        {
            var result = await dbcontext.Tasks.FindAsync(id);

            if (result == null || result.UserId != CurrentUserId)
                return NotFound();

            return result;
        }

        [HttpPost]
        [Route("AddTasks")]
        public async Task<Tasks> AddTasks(Tasks tasks)
        {
            tasks.Id = 0;
            tasks.UserId = CurrentUserId;

            dbcontext.Add(tasks);
            await dbcontext.SaveChangesAsync();
            return tasks;
        }

        [HttpPut]
        [Route("UpdateTasks/{id}")]
        public async Task<ActionResult<Tasks>> UpdateTasks(int id, Tasks tasks)
        {
            var result = await dbcontext.Tasks.FindAsync(id);

            if (result == null || result.UserId != CurrentUserId)
                return NotFound();

            result.Title = tasks.Title;
            result.IsCompleted = tasks.IsCompleted;
            result.Priority = tasks.Priority;

            await dbcontext.SaveChangesAsync();

            return result;
        }

        [HttpDelete]
        [Route("DeleteTasks/{id}")]
        public async Task<bool> DeleteTasks(int id)
        {
            var islem = false;

            var result = await dbcontext.Tasks.FindAsync(id);

            if (result != null && result.UserId == CurrentUserId)
            {
                islem = true;
                dbcontext.Remove(result);
                await dbcontext.SaveChangesAsync();
            }

            return islem;
        }

        [HttpGet]
        [Route("SearchTasks")]
        public async Task<IEnumerable<Tasks>> SearchTasks(string keyword)
        {
            return await dbcontext.Tasks
                .Where(x => x.UserId == CurrentUserId &&
                            (x.Title.Contains(keyword) || x.Priority.Contains(keyword)))
                .ToListAsync();
        }
    }
}
