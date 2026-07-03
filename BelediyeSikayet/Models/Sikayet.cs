using System;
using System.Collections.Generic;

namespace BelediyeSikayet.Models;

public partial class Sikayet
{
    public int SikayetId { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string? Email { get; set; }

    public string Ilce { get; set; } = null!;

    public string Baslik { get; set; } = null!;

    public string Aciklama { get; set; } = null!;

    public int KategoriId { get; set; }

    public int DurumId { get; set; }

    public bool IsPublic { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Cevap> Cevaps { get; set; } = new List<Cevap>();

    public virtual Durum Durum { get; set; } = null!;

    public virtual Kategori Kategori { get; set; } = null!;
}
