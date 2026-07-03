using System;
using System.Collections.Generic;

namespace BelediyeSikayet.Models;

public partial class Kategori
{
    public int KategoriId { get; set; }

    public string Ad { get; set; } = null!;

    public virtual ICollection<Sikayet> Sikayets { get; set; } = new List<Sikayet>();
}
