using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class CarritoConfig : IEntityTypeConfiguration<Carrito>
    {
        public void Configure(EntityTypeBuilder<Carrito> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("carritos");

            builder.HasIndex(e => e.UsuarioId, "usuario_id");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("carrito_id");
            builder.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            builder.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            builder.HasOne(d => d.Usuario).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("carritos_ibfk_1");
        }
    }
}