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
    public class QuotesController : ControllerBase
    {
        private readonly AppDbContext dbcontext;

        public QuotesController(AppDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        [HttpGet]
        [Route("GetQuotes")]
        public async Task<IEnumerable<Quotes>> GetQuotes()
        {
            return await dbcontext.Quotes
                .Where(x => x.UserId == CurrentUserId)
                .ToListAsync();
        }

        [HttpGet]
        [Route("GetQuotesById/{id}")]
        public async Task<ActionResult<Quotes>> GetQuotesById(int id)
        {
            var result = await dbcontext.Quotes.FindAsync(id);

            if (result == null || result.UserId != CurrentUserId)
                return NotFound();

            return result;
        }

        [HttpPost]
        [Route("AddQuotes")]
        public async Task<Quotes> AddQuotes(Quotes quotes)
        {
            quotes.Id = 0;
            quotes.UserId = CurrentUserId;

            dbcontext.Add(quotes);
            await dbcontext.SaveChangesAsync();
            return quotes;
        }

        [HttpPut]
        [Route("UpdateQuotes/{id}")]
        public async Task<ActionResult<Quotes>> UpdateQuotes(int id, Quotes quotes)
        {
            var result = await dbcontext.Quotes.FindAsync(id);

            if (result == null || result.UserId != CurrentUserId)
                return NotFound();

            result.Text = quotes.Text;
            result.Author = quotes.Author;

            await dbcontext.SaveChangesAsync();

            return result;
        }

        [HttpDelete]
        [Route("DeleteQuotes/{id}")]
        public async Task<bool> DeleteQuotes(int id)
        {
            var islem = false;

            var result = await dbcontext.Quotes.FindAsync(id);

            if (result != null && result.UserId == CurrentUserId)
            {
                islem = true;
                dbcontext.Remove(result);
                await dbcontext.SaveChangesAsync();
            }

            return islem;
        }

        [HttpGet]
        [Route("SearchQuotes")]
        public async Task<IEnumerable<Quotes>> SearchQuotes(string keyword)
        {
            return await dbcontext.Quotes
                .Where(x => x.UserId == CurrentUserId &&
                            (x.Text.Contains(keyword) || x.Author.Contains(keyword)))
                .ToListAsync();
        }
    }
}
