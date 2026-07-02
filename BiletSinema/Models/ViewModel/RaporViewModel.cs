using BiletSinema.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BiletSinema.ViewModels
{
    public class RaporViewModel
    {
        public List<FilmRaporVM> FilmRaporu { get; set; }
        public List<KategoriRaporVM> KategoriRaporu { get; set; }
        public List<RaporGroupVM> GroupRaporu { get; set; }

        public FilmRaporVM EnYuksekFilm { get; set; }
        public Diziler EnYuksekDizi { get; set; }
        public Tiyatrolar EnYuksekTiyatro { get; set; }

        public GenelRaporVM GenelRapor { get; set; }

        public int SecilenRapor { get; set; }
        public List<SelectListItem> RaporListesi { get; set; }
    }

    public class FilmRaporVM
    {
        public string FilmAdi { get; set; }
        public string KategoriAdi { get; set; }
        public double Puan { get; set; }
    }

    public class KategoriRaporVM
    {
        public string KategoriAdi { get; set; }
        public string FilmAdi { get; set; }
    }

    public class RaporGroupVM
    {
        public string KategoriAdi { get; set; }
        public int FilmSayisi { get; set; }
        public double OrtalamaPuan { get; set; }
    }

    public class GenelRaporVM
    {
        public int ToplamFilm { get; set; }
        public int ToplamDizi { get; set; }
        public int ToplamTiyatro { get; set; }

        public double OrtalamaFilmPuan { get; set; }
        public double OrtalamaDiziPuan { get; set; }
        public double OrtalamaTiyatroPuan { get; set; }
    }
}