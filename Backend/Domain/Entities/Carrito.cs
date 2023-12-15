using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Carrito : BaseEntity
{
    public int? UsuarioId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Detallescarrito> Detallescarritos { get; set; } = new List<Detallescarrito>();

    public virtual Usuario Usuario { get; set; }
}
