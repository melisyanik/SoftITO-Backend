using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMunicipality.MODEL
{
    public class Announcement
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime PublishDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; }
    }
}
