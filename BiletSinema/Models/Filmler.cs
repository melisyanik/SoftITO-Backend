using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiletSinema.Models
{
    public class Filmler
    {
        [Key]
        public int FilmNo { get; set; }

        public string Adi { get; set; }

        public DateTime Tarihi { get; set; }

        public string Yorum { get; set; }

        public double Puan { get; set; }

        [ForeignKey("kategori")]
        public int KategoriNo { get; set; }

        public virtual Kategori kategori { get; set; }
    }
}
