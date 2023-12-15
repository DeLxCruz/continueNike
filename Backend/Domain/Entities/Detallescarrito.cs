using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Detallescarrito : BaseEntity
{
    public int? CarritoId { get; set; }

    public int? ProductoId { get; set; }

    public int Cantidad { get; set; }

    public virtual Carrito Carrito { get; set; }

    public virtual Producto Producto { get; set; }
}
