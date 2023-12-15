using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class DetallesTransaccionConfig : IEntityTypeConfiguration<Detallestransaccion>
    {
        public void Configure(EntityTypeBuilder<Detallestransaccion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("detallestransaccion");

            builder.HasIndex(e => e.ProductoId, "producto_id");

            builder.HasIndex(e => e.TransaccionId, "transaccion_id");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("detalle_transaccion_id");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precio_unitario");
            builder.Property(e => e.ProductoId).HasColumnName("producto_id");
            builder.Property(e => e.TransaccionId).HasColumnName("transaccion_id");

            builder.HasOne(d => d.Producto).WithMany(p => p.Detallestransaccions)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("detallestransaccion_ibfk_2");

            builder.HasOne(d => d.Transaccion).WithMany(p => p.Detallestransaccions)
                .HasForeignKey(d => d.TransaccionId)
                .HasConstraintName("detallestransaccion_ibfk_1");
        }
    }
}