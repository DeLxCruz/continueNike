using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Producto : BaseEntity
{

    public string NombreProducto { get; set; } = null!;

    public string Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Existencias { get; set; }

    public int? StockMinimo { get; set; }

    public int? StockMaximo { get; set; }

    public string UrlProducto { get; set; }

    public virtual ICollection<Detallescarrito> Detallescarritos { get; set; } = new List<Detallescarrito>();

    public virtual ICollection<Detallespedido> Detallespedidos { get; set; } = new List<Detallespedido>();

    public virtual ICollection<Detallestransaccion> Detallestransaccions { get; set; } = new List<Detallestransaccion>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Categoria> Categoria { get; set; } = new List<Categoria>();
}
