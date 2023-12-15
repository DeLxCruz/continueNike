using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Detallestransaccion : BaseEntity
{
    public int? TransaccionId { get; set; }

    public int? ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Producto Producto { get; set; }

    public virtual Transacciones Transaccion { get; set; }
}
