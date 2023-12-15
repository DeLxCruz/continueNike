using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Categoria : BaseEntity
{
    public string NombreCategoria { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
