using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class UsuarioMetadata : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.LimitacionesId)
                .IsRequired();

            builder.Property(x => x.PersonaId)
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.EstaBloqueado)
                .HasColumnType<bool>("bit")
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
