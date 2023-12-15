using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Detallespedido :  BaseEntity
{
    public int? PedidoId { get; set; }

    public int? ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Pedido Pedido { get; set; }

    public virtual Producto Producto { get; set; }
}
