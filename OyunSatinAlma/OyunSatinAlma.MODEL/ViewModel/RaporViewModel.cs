using System;
using System.Collections.Generic;

namespace OyunSatinAlma.MODEL.ViewModel
{
    public class RaporViewModel
    {
        public List<SiparisRapor> SiparisRapor { get; set; }
        public List<OyunRapor> OyunRapor { get; set; }
        public List<MusteriRapor> MusteriRapor { get; set; }
        public List<OyunSatisGroup> OyunSatisRapor { get; set; }
        public List<SonSiparisRapor> SonSiparisRapor { get; set; }
    }

    public class SiparisRapor
    {
        public int SiparisId { get; set; }
        public string OyunAdi { get; set; }
        public string MusteriAdi { get; set; }
        public string Durum { get; set; }
    }

    public class OyunRapor
    {
        public string OyunAdi { get; set; }
        public decimal Fiyat { get; set; }
    }

    public class MusteriRapor
    {
        public string MusteriAdi { get; set; }
        public int SiparisSayisi { get; set; }
    }

    public class OyunSatisGroup
    {
        public string OyunAdi { get; set; }
        public int SatisSayisi { get; set; }
        public decimal ToplamGelir { get; set; }
    }

    public class SonSiparisRapor
    {
        public int SiparisId { get; set; }
        public string OyunAdi { get; set; }
        public DateTime Tarih { get; set; }
    }
}