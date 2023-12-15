using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Usuario : BaseEntity
{
    public string NombreUsuario { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int? RolId { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual Role Rol { get; set; }

    public virtual ICollection<Transacciones> Transacciones { get; set; } = new List<Transacciones>();

    public virtual Usuarioscompra Usuarioscompra { get; set; }

    public ICollection<Role> Rols { get; set; } = new HashSet<Role>();
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

}
