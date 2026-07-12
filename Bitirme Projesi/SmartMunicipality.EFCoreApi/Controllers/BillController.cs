using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.EFCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BillController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
        {
            return await _context.Bills
                .Include(b => b.Subscription)
                .ThenInclude(s => s.ServiceType)
                .OrderByDescending(b => b.CreatedDate)
                .ToListAsync();
        }

        
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBillsByUser(string userId)
        {
            return await _context.Bills
                .Include(b => b.Subscription)
                .ThenInclude(s => s.ServiceType)
                .Where(b => b.Subscription.UserId == userId)
                .OrderByDescending(b => b.CreatedDate)
                .ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBill(int id)
        {
            var bill = await _context.Bills
                .Include(b => b.Subscription)
                .ThenInclude(s => s.ServiceType)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (bill == null) return NotFound();

            return bill;
        }

        
        [HttpPost]
        public async Task<ActionResult<Bill>> PostBill(Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();

            
            try
            {
                var sub = await _context.Subscriptions.FindAsync(bill.SubscriptionId);
                if (sub != null)
                {
                    var notification = new Notification
                    {
                        UserId = sub.UserId,
                        Title = "Yeni Fatura Tanımlandı",
                        Message = $"Aboneliğinize ait {bill.BillMonth}/{bill.BillYear} dönemi {bill.Amount} TL tutarında yeni fatura oluşturulmuştur. Son ödeme tarihi: {bill.DueDate.ToShortDateString()}",
                        IsRead = false,
                        CreatedDate = DateTime.Now,
                        NotificationType = "Bill"
                    };
                    _context.Notifications.Add(notification);
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                
            }

            return CreatedAtAction(nameof(GetBill), new { id = bill.Id }, bill);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBill(int id, Bill bill)
        {
            if (id != bill.Id) return BadRequest();

            _context.Entry(bill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Bills.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBill(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            if (bill == null) return NotFound();

            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
