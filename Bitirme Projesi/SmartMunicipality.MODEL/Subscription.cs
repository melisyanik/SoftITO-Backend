using SmartMunicipality.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMunicipality.MODEL
{
    public class Subscription
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public ApplicationUser? User { get; set; }

        public int ServiceTypeId { get; set; }

        public ServiceType? ServiceType { get; set; }

        public string SubscriberNo { get; set; } = string.Empty;
        public string MeterNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<ConsumptionRecord> ConsumptionRecords { get; set; } = new List<ConsumptionRecord>();

        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}
