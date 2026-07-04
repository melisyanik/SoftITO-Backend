using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LifeTrackerApi.Data;
using LifeTrackerApi.Models;

namespace LifeTrackerApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseLogController : ControllerBase
    {
        private readonly AppDbContext context;

        public ExpenseLogController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("GetExpenseLogs")]
        public async Task<IEnumerable<ExpenseLog>> GetExpenseLog()
        {
            return await context.ExpenseLogs.ToListAsync();
        }

        [HttpPost]
        [Route("AddExpenseLog")]
        public async Task<ExpenseLog> AddExpenseLog(ExpenseLog expense)
        {
            context.ExpenseLogs.Add(expense);
            await context.SaveChangesAsync();
            return expense;
        }

        [HttpPut]
        [Route("UpdateExpenseLog")]
        public async Task<ExpenseLog> UpdateExpenseLog(ExpenseLog expense)
        {
            context.Entry(expense).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return expense;
        }

        [HttpDelete]
        [Route("DeleteExpenseLog/{id}")]
        public async Task<bool> DeleteExpenseLog(int id)
        {
            var data = await context.ExpenseLogs.FindAsync(id);

            if (data == null)
                return false;

            context.ExpenseLogs.Remove(data);
            await context.SaveChangesAsync();
            return true;
        }
    }
}