using System;
using System.Collections.Generic;

namespace OdevSoru1.Model;

public partial class Rehber
{
    public int RehberId { get; set; }

    public string Ad { get; set; } = null!;

    public string? Soyad { get; set; }

    public string? Telefon { get; set; }
}
