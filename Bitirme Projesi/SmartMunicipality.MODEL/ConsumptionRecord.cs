using SmartMunicipality.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMunicipality.MODEL
{
    public class ConsumptionRecord
    {
        public int Id { get; set; }

        public int SubscriptionId { get; set; }

        public Subscription? Subscription { get; set; }

        public decimal ConsumptionValue { get; set; }

        public DateTime RecordDate { get; set; }
    }
}