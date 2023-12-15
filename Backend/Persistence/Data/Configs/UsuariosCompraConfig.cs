using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class UsuariosCompraConfig : IEntityTypeConfiguration<Usuarioscompra>
    {
        public void Configure(EntityTypeBuilder<Usuarioscompra> builder)
        {
            builder.HasKey(e => e.UsuarioId).HasName("PRIMARY");

            builder.ToTable("usuarioscompras");

            builder.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasColumnName("usuario_id");
            builder.Property(e => e.TotalCompras)
                .HasPrecision(10, 2)
                .HasColumnName("total_compras");

            builder.HasOne(d => d.Usuario).WithOne(p => p.Usuarioscompra)
                .HasForeignKey<Usuarioscompra>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarioscompras_ibfk_1");
        }
    }
}