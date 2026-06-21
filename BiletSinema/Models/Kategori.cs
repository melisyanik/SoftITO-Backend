using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiletSinema.Models
{
    public class Kategori
    {
            [Key]
            public int KategoriNo
            {
                get; set;
            }

            public string KategoriAdi
            {
                get; set;
            }

        public virtual ICollection<Filmler> Filmler { get; set; }
        public virtual ICollection<Diziler> Diziler { get; set; }
        public virtual ICollection<Tiyatrolar> Tiyatrolar { get; set; }

    }
}
