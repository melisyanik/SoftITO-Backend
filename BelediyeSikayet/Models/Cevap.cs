using System;
using System.Collections.Generic;

namespace BelediyeSikayet.Models;

public partial class Cevap
{
    public int CevapId { get; set; }

    public int SikayetId { get; set; }

    public string Aciklama { get; set; } = null!;

    public DateTime CevapTarihi { get; set; }

    public virtual Sikayet Sikayet { get; set; } = null!;
}
