using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunSatinAlma.MODEL
{
    public class Oyun
    {
        [Key]
        public int OyunId { get; set; }

        [Required]
        public string OyunAdi { get; set; }

        public decimal Fiyat { get; set; }

        public string ResimUrl { get; set; }

        public string Tur { get; set; }
    }
}
