using System;
using System.Collections.Generic;

namespace ProyectoDesAppsPT2.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? ApellidoUsuario { get; set; }

    public string? EmailUsuario { get; set; }

    public string? TelefonoUsuario { get; set; }

    public string? DireccionUsuario { get; set; }

    public int? IdTipo { get; set; }

    public virtual Tipo? IdTipoNavigation { get; set; }
}
