using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class DetallesCarritoConfig : IEntityTypeConfiguration<Detallescarrito>
    {
        public void Configure(EntityTypeBuilder<Detallescarrito> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("detallescarrito");

            builder.HasIndex(e => e.CarritoId, "carrito_id");

            builder.HasIndex(e => e.ProductoId, "producto_id");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("detalle_carrito_id");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.CarritoId).HasColumnName("carrito_id");
            builder.Property(e => e.ProductoId).HasColumnName("producto_id");

            builder.HasOne(d => d.Carrito).WithMany(p => p.Detallescarritos)
                .HasForeignKey(d => d.CarritoId)
                .HasConstraintName("detallescarrito_ibfk_1");

            builder.HasOne(d => d.Producto).WithMany(p => p.Detallescarritos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("detallescarrito_ibfk_2");
        }
    }
}