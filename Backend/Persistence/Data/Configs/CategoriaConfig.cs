using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("categorias");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("categoria_id");
            builder.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .HasColumnName("nombre_categoria");
        }
    }
}