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
    public class NotesController : ControllerBase
    {
        private readonly AppDbContext dbcontext;

        public NotesController(AppDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        private string GetUserId() => User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

        [HttpGet]
        [Route("GetNotes")]
        public async Task<IEnumerable<Notes>> GetNotes()
        {
            return await dbcontext.Notes
                .Where(x => x.UserId == GetUserId())
                .ToListAsync();
        }

        [HttpGet]
        [Route("GetNotesById/{id}")]
        public async Task<ActionResult<Notes>> GetNotesById(int id)
        {
            var result = await dbcontext.Notes.FindAsync(id);

            if (result == null || result.UserId != GetUserId())
                return NotFound();

            return result;
        }

        [HttpPost]
        [Route("AddNotes")]
        public async Task<Notes> AddNotes(Notes notes)
        {
            notes.Id = 0;
            notes.UserId = GetUserId();

            dbcontext.Add(notes);
            await dbcontext.SaveChangesAsync();
            return notes;
        }

        [HttpPut]
        [Route("UpdateNotes/{id}")]
        public async Task<ActionResult<Notes>> UpdateNotes(int id, Notes notes)
        {
            var result = await dbcontext.Notes.FindAsync(id);

            if (result == null || result.UserId != CurrentUserId)
                return NotFound();

            result.Title = notes.Title;
            result.Content = notes.Content;
            await dbcontext.SaveChangesAsync();

            return result;
        }

        [HttpDelete]
        [Route("DeleteNotes/{id}")]
        public async Task<bool> DeleteNotes(int id)
        {
            var islem = false;

            var result = await dbcontext.Notes.FindAsync(id);

            if (result != null && result.UserId == CurrentUserId)
            {
                islem = true;
                dbcontext.Remove(result);
                await dbcontext.SaveChangesAsync();
            }

            return islem;
        }

        [HttpGet]
        [Route("SearchNotes")]
        public async Task<IEnumerable<Notes>> SearchNotes(string keyword)
        {
            return await dbcontext.Notes
                .Where(x => x.UserId == CurrentUserId &&
                            (x.Title.Contains(keyword) || x.Content.Contains(keyword)))
                .ToListAsync();
        }
    }
}
