using System.Collections.Generic;

namespace BiletSinema.Models
{
    public class HomeViewModel
    {
        public List<Filmler> Filmler { get; set; }
        public List<Diziler> Diziler { get; set; }
        public List<Tiyatrolar> Tiyatrolar { get; set; }
    }
}
