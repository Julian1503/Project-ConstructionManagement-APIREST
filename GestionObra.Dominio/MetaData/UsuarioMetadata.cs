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
            builder.HasData(Seed());

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

        private List<Usuario> Seed()
        {
            return new List<Usuario>
            {
                new Usuario
                {
                    Id=1, PersonaId=1,EstaEliminado = false,EstaBloqueado = false,UserName = "juliamm1503",Password = "123456",LimitacionesId = 0
                }
            };
        }
    }
}
