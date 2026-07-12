using SmartMunicipality.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMunicipality.MODEL
{
    public class Payment
    {
        public int Id { get; set; }

        public int BillId { get; set; }

        public Bill? Bill { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string ReceiptNumber { get; set; } = string.Empty;

        public string PaymentMethod { get; set; } = string.Empty;

        public string TransactionNo { get; set; } = string.Empty;
    }
}