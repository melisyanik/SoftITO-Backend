using SmartMunicipality.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMunicipality.MODEL
{
    public class Bill
    {
        public int Id { get; set; }

        public int SubscriptionId { get; set; }

        public Subscription? Subscription { get; set; }

        public string BillNo { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime DueDate { get; set; }

        public int BillMonth { get; set; }

        public int BillYear { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}