using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Role : BaseEntity
{
    public string NombreRol { get; set; } = null!;

    public ICollection<Usuario> Users { get; set; } = new HashSet<Usuario>();

}
