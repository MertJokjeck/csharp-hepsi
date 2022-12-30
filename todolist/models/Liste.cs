using System;
using System.Collections.Generic;

namespace todolist.Models;

public partial class Liste
{
    public int Sirano { get; set; }

    public string Ad { get; set; } = null!;

    public string Bolum { get; set; } = null!;

    public DateOnly Dogumtarihi { get; set; }
}
