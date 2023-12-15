using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class DetallesPedidoConfig : IEntityTypeConfiguration<Detallespedido>
    {
        public void Configure(EntityTypeBuilder<Detallespedido> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("detallespedido");

            builder.HasIndex(e => e.PedidoId, "pedido_id");

            builder.HasIndex(e => e.ProductoId, "producto_id");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("detalle_id");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.PedidoId).HasColumnName("pedido_id");
            builder.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precio_unitario");
            builder.Property(e => e.ProductoId).HasColumnName("producto_id");

            builder.HasOne(d => d.Pedido).WithMany(p => p.Detallespedidos)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("detallespedido_ibfk_1");

            builder.HasOne(d => d.Producto).WithMany(p => p.Detallespedidos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("detallespedido_ibfk_2");
        }
    }
}