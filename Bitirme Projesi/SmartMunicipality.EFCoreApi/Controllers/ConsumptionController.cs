using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.EFCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConsumptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumptionRecord>>> GetConsumptionRecords()
        {
            return await _context.ConsumptionRecords.ToListAsync();
        }

        
        [HttpGet("Subscription/{subscriptionId}")]
        public async Task<ActionResult<IEnumerable<ConsumptionRecord>>> GetConsumptionRecordsBySubscription(int subscriptionId)
        {
            return await _context.ConsumptionRecords
                .Where(c => c.SubscriptionId == subscriptionId)
                .OrderByDescending(c => c.RecordDate)
                .ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumptionRecord>> GetConsumptionRecord(int id)
        {
            var record = await _context.ConsumptionRecords.FindAsync(id);
            if (record == null) return NotFound();
            return record;
        }

        
        [HttpPost]
        public async Task<ActionResult<ConsumptionRecord>> PostConsumptionRecord(ConsumptionRecord record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ConsumptionRecords.Add(record);
            await _context.SaveChangesAsync();

            
            try
            {
                var subscription = await _context.Subscriptions
                    .Include(s => s.ServiceType)
                    .FirstOrDefaultAsync(s => s.Id == record.SubscriptionId);

                if (subscription != null && subscription.ServiceType != null)
                {
                    var lastRecord = await _context.ConsumptionRecords
                        .Where(c => c.SubscriptionId == record.SubscriptionId && c.Id != record.Id)
                        .OrderByDescending(c => c.RecordDate)
                        .FirstOrDefaultAsync();

                    decimal consumptionDiff = record.ConsumptionValue;
                    if (lastRecord != null)
                    {
                        consumptionDiff = record.ConsumptionValue - lastRecord.ConsumptionValue;
                    }

                    
                    if (consumptionDiff > 0 && subscription.ServiceType.Name != "Emlak Vergisi")
                    {
                        decimal unitPrice = 25.5m; 
                        if (subscription.ServiceType.Name.Contains("Gaz") || subscription.ServiceType.Name.Contains("Doğalgaz"))
                        {
                            unitPrice = 6.5m;
                        }
                        else if (subscription.ServiceType.Name.Contains("Su"))
                        {
                            unitPrice = 25.5m;
                        }

                        decimal amount = Math.Round(consumptionDiff * unitPrice, 2);

                        var bill = new Bill
                        {
                            SubscriptionId = record.SubscriptionId,
                            BillNo = $"FAT-{DateTime.Now:yyyyMM}-AUTO-{new Random().Next(1000, 9999)}",
                            Amount = amount,
                            DueDate = DateTime.Now.AddDays(15),
                            BillMonth = DateTime.Now.Month,
                            BillYear = DateTime.Now.Year,
                            Status = "Ödenmedi",
                            CreatedDate = DateTime.Now
                        };

                        _context.Bills.Add(bill);
                        await _context.SaveChangesAsync();

                        
                        var notification = new Notification
                        {
                            UserId = subscription.UserId,
                            Title = "Yeni Fatura Tanımlandı (Otomatik)",
                            Message = $"Aboneliğinize ait ({subscription.SubscriberNo}) {bill.BillMonth}/{bill.BillYear} dönemi {bill.Amount} TL tutarında otomatik fatura oluşturulmuştur. Son tüketim miktarı: {consumptionDiff} m³. Son ödeme tarihi: {bill.DueDate.ToString("dd.MM.yyyy")}",
                            IsRead = false,
                            CreatedDate = DateTime.Now,
                            NotificationType = "Bill"
                        };
                        _context.Notifications.Add(notification);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                
            }

            
            try
            {
                var subscription = await _context.Subscriptions
                    .Include(s => s.ServiceType)
                    .FirstOrDefaultAsync(s => s.Id == record.SubscriptionId);

                if (subscription != null)
                {
                    
                    var previousRecords = await _context.ConsumptionRecords
                        .Where(c => c.SubscriptionId == record.SubscriptionId && c.Id != record.Id)
                        .OrderByDescending(c => c.RecordDate)
                        .Take(3)
                        .ToListAsync();

                    if (previousRecords.Any())
                    {
                        var average = previousRecords.Average(c => c.ConsumptionValue);
                        
                        
                        if (average > 0 && record.ConsumptionValue >= average * 2)
                        {
                            var alert = new AIAlert
                            {
                                UserId = subscription.UserId,
                                AlertType = subscription.ServiceType?.Name ?? "Tüketim",
                                Description = $"Olası {subscription.ServiceType?.Name?.ToLower()} kaçağı tespit edildi! Son okuma değeri ({record.ConsumptionValue}) önceki ortalamanın ({Math.Round(average, 2)}) çok üzerindedir.",
                                CreatedDate = DateTime.Now
                            };
                            _context.AIAlerts.Add(alert);

                            
                            var notification = new Notification
                            {
                                UserId = subscription.UserId,
                                Title = "Akıllı Tüketim Uyarısı",
                                Message = $"Aboneliğinizde ({subscription.SubscriberNo}) ani tüketim artışı tespit edildi. {alert.Description}",
                                IsRead = false,
                                CreatedDate = DateTime.Now,
                                NotificationType = "Alert"
                            };
                            _context.Notifications.Add(notification);

                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }

            return CreatedAtAction(nameof(GetConsumptionRecord), new { id = record.Id }, record);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumptionRecord(int id, ConsumptionRecord record)
        {
            if (id != record.Id) return BadRequest();

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ConsumptionRecords.Any(e => e.Id == id))
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
        public async Task<IActionResult> DeleteConsumptionRecord(int id)
        {
            var record = await _context.ConsumptionRecords.FindAsync(id);
            if (record == null) return NotFound();

            _context.ConsumptionRecords.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
