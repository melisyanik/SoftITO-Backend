using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMunicipality.MODEL
{
    public class Complaint
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CategoryId { get; set; }

        public ComplaintCategory? Category { get; set; }
        public int StatusId { get; set; }
        public ComplaintStatus? Status { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        public ICollection<ComplaintResponse> Responses { get; set; } = new List<ComplaintResponse>();
    }
}
