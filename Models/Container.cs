using System;
using System.Collections.Generic;

namespace PortoAPI.Models;

public partial class Container
{
    public int Id { get; set; }

    public string NumeroDeSerie { get; set; } = null!;

    public string Cliente { get; set; } = null!;

    public int Tipo { get; set; }

    public string Status { get; set; } = null!;

    public string Categoria { get; set; } = null!;
}
