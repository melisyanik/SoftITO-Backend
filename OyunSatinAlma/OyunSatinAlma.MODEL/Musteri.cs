using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunSatinAlma.MODEL
{
    public class Musteri
    {
        [Key]
        public int MusteriId { get; set; }

        [Required]
        public string AdSoyad { get; set; }

        public string Telefon { get; set; }

        public string Email { get; set; }
    }
}
