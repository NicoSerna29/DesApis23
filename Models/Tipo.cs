using System;
using System.Collections.Generic;

namespace ProyectoDesAppsPT2.Models;

public partial class Tipo
{
    public int IdTipo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
