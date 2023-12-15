using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class InventarioConfig : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("inventarios");

            builder.HasIndex(e => e.ProductoId, "producto_id");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("inventario_id");
            builder.Property(e => e.CantidadAnterior).HasColumnName("cantidad_anterior");
            builder.Property(e => e.CantidadNueva).HasColumnName("cantidad_nueva");
            builder.Property(e => e.FechaMovimiento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_movimiento");
            builder.Property(e => e.ProductoId).HasColumnName("producto_id");

            builder.HasOne(d => d.Producto).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("inventarios_ibfk_1");
        }
    }
}