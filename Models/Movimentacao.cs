using System;
using System.Collections.Generic;

namespace PortoAPI.Models;

public partial class Movimentacao
{
    public int Id { get; set; }

    public string NumeroDeContainer { get; set; } = null!;

    public string Cliente { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public DateTime Inicio { get; set; }

    public DateTime Fim { get; set; }
}
