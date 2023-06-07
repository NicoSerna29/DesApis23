using System;
using System.Collections.Generic;

namespace ProyectoDesAppsPT2.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Descripcion { get; set; }

    public string? EmailUsuario { get; set; }

    public long? TelefonoUsuario { get; set; }

    public string? DireccionUsuario { get; set; }

    public DateTime? FechaConsulta { get; set; }
}
