using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("usuarios");

            builder.HasIndex(e => e.RolId, "rol_id");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("usuario_id");
            builder.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .HasColumnName("contrasena");
            builder.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("correo_electronico");
            builder.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .HasColumnName("nombre_usuario");
            builder.Property(e => e.RolId).HasColumnName("rol_id");

            builder.HasOne(d => d.Rol).WithMany(p => p.Users)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("usuarios_ibfk_1");
        }
    }
}