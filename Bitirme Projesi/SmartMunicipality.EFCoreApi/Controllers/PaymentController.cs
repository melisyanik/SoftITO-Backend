using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.EFCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return await _context.Payments
                .Include(p => p.Bill)
                .ThenInclude(b => b.Subscription)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _context.Payments
                .Include(p => p.Bill)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (payment == null) return NotFound();
            return payment;
        }

        
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(PaymentCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            var bill = await _context.Bills.FindAsync(dto.BillId);
            if (bill == null)
            {
                return BadRequest(new { Message = "Ödenmek istenen fatura bulunamadı." });
            }

            if (bill.Status == "Ödendi")
            {
                return BadRequest(new { Message = "Bu fatura zaten ödenmiştir." });
            }

            
            var payment = new Payment
            {
                BillId = dto.BillId,
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod ?? "Kredi Kartı",
                PaymentDate = DateTime.Now,
                TransactionNo = "TRX-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                ReceiptNumber = "REC-" + new Random().Next(100000, 999999)
            };

            _context.Payments.Add(payment);

            
            bill.Status = "Ödendi";
            _context.Entry(bill).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            
            try
            {
                var sub = await _context.Subscriptions.FindAsync(bill.SubscriptionId);
                if (sub != null)
                {
                    var notification = new Notification
                    {
                        UserId = sub.UserId,
                        Title = "Ödeme Alındı",
                        Message = $"Aboneliğinize ait ({sub.SubscriberNo}) {bill.BillMonth}/{bill.BillYear} dönemi {bill.Amount} TL faturanız başarıyla ödenmiştir. Makbuz No: {payment.ReceiptNumber}",
                        IsRead = false,
                        CreatedDate = DateTime.Now,
                        NotificationType = "Payment"
                    };
                    _context.Notifications.Add(notification);
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                
            }

            payment.Bill = null;
            return Ok(payment);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _context.Payments.Include(p => p.Bill).FirstOrDefaultAsync(p => p.Id == id);
            if (payment == null) return NotFound();

            
            if (payment.Bill != null)
            {
                payment.Bill.Status = "Ödenmedi";
                _context.Entry(payment.Bill).State = EntityState.Modified;
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class PaymentCreateDto
    {
        public int BillId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
