using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configs
{
    public class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("refresh_tokens");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("refresh_token_id");

            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.Property(e => e.Token)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("token");

            builder.Property(e => e.ExpiryDate)
                .IsRequired()
                .HasColumnName("expiry_date");

            builder.HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("FK_refresh_tokens_usuarios_UsuarioId");
        }
    }
}