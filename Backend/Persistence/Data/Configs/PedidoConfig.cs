using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("pedidos");

            builder.HasIndex(e => e.UsuarioId, "usuario_id");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("pedido_id");
            builder.Property(e => e.EstadoPedido)
                .HasMaxLength(20)
                .HasColumnName("estado_pedido");
            builder.Property(e => e.FechaPedido).HasColumnName("fecha_pedido");
            builder.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            builder.HasOne(d => d.Usuario).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("pedidos_ibfk_1");
        }
    }
}