using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("productos");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("producto_id");
            builder.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            builder.Property(e => e.Existencias).HasColumnName("existencias");
            builder.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .HasColumnName("nombre_producto");
            builder.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            builder.Property(e => e.StockMaximo)
                .HasDefaultValueSql("'100'")
                .HasColumnName("stock_maximo");
            builder.Property(e => e.StockMinimo)
                .HasDefaultValueSql("'0'")
                .HasColumnName("stock_minimo");
            builder.Property(e => e.UrlProducto)
                .HasMaxLength(255)
                .HasColumnName("url_producto");

            builder.HasMany(d => d.Categoria).WithMany(p => p.Productos)
                .UsingEntity<Dictionary<string, object>>(
                    "Productoscategoria",
                    r => r.HasOne<Categoria>().WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productoscategorias_ibfk_2"),
                    l => l.HasOne<Producto>().WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productoscategorias_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ProductoId", "CategoriaId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("productoscategorias");
                        j.HasIndex(new[] { "CategoriaId" }, "categoria_id");
                        j.IndexerProperty<int>("ProductoId").HasColumnName("producto_id");
                        j.IndexerProperty<int>("CategoriaId").HasColumnName("categoria_id");
                    });
        }
    }
}