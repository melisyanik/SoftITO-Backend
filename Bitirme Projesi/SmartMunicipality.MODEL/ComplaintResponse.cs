using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMunicipality.MODEL
{
    public class ComplaintResponse
    {
        public int Id { get; set; }

        public int ComplaintId { get; set; }

        public Complaint? Complaint { get; set; }

        public string ResponseText { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; } = string.Empty;

        public ApplicationUser? User { get; set; }
    }
}
