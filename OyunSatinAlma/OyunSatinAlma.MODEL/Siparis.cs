using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunSatinAlma.MODEL
{
    public class Siparis
    {
        [Key]
        public int SiparisId { get; set; }

        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; }

        public int OyunId { get; set; }
        public Oyun Oyun { get; set; }

        public DateTime SiparisTarihi { get; set; }

        public string Durum { get; set; }
    }
}
