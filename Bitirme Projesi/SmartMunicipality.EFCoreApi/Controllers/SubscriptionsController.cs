using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.EFCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptions()
        {
            var subs = await _context.Subscriptions
                .Include(s => s.ServiceType)
                .Include(s => s.User)
                .ToListAsync();

            foreach(var s in subs) {
                if(s.ServiceType != null) {
                    s.ServiceType.Subscriptions = null;
                }
                if(s.User != null) {
                    s.User.PasswordHash = null;
                    s.User.SecurityStamp = null;
                }
            }
            return subs;
        }

        
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptionsByUser(string userId)
        {
            var subs = await _context.Subscriptions
                .Include(s => s.ServiceType)
                .Where(s => s.UserId == userId)
                .ToListAsync();
            
            
            foreach(var s in subs) {
                if(s.ServiceType != null) {
                    s.ServiceType.Subscriptions = null;
                }
            }
            return subs;
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscription>> GetSubscription(int id)
        {
            var subscription = await _context.Subscriptions
                .Include(s => s.ServiceType)
                .Include(s => s.Bills)
                .Include(s => s.ConsumptionRecords)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (subscription == null)
            {
                return NotFound();
            }

            if(subscription.ServiceType != null) {
                subscription.ServiceType.Subscriptions = null;
            }
            if(subscription.Bills != null) {
                foreach(var b in subscription.Bills) { b.Subscription = null; }
            }
            if(subscription.ConsumptionRecords != null) {
                foreach(var c in subscription.ConsumptionRecords) { c.Subscription = null; }
            }

            return subscription;
        }

        
        [HttpGet("Bill/{billId}")]
        public async Task<ActionResult<Bill>> GetBill(int billId)
        {
            var bill = await _context.Bills
                .Include(b => b.Subscription)
                .ThenInclude(s => s.ServiceType)
                .FirstOrDefaultAsync(b => b.Id == billId);

            if (bill == null) return NotFound();
            
            if(bill.Subscription != null) {
                bill.Subscription.Bills = null;
                if(bill.Subscription.ServiceType != null) {
                    bill.Subscription.ServiceType.Subscriptions = null;
                }
            }

            
            if(bill.Subscription != null && !string.IsNullOrEmpty(bill.Subscription.UserId)) {
                var user = await _context.Users.FindAsync(bill.Subscription.UserId);
                bill.Subscription.User = user;
            }

            return bill;
        }

        
        [HttpPost]
        public async Task<ActionResult<Subscription>> PostSubscription(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubscription), new { id = subscription.Id }, subscription);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscription(int id, Subscription subscription)
        {
            if (id != subscription.Id)
            {
                return BadRequest();
            }

            _context.Entry(subscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionExists(id))
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
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptionExists(int id)
        {
            return _context.Subscriptions.Any(e => e.Id == id);
        }
    }
}
