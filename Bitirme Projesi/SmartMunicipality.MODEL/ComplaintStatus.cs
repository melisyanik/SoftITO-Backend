using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMunicipality.MODEL
{
    public class ComplaintStatus
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
    }
}
