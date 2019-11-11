using System.Collections.Generic;
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

            builder.Property(x => x.IdentificacionId)
                .IsRequired();

            builder.Property(x => x.EmpleadoId)
                .IsRequired();

            builder.Property(x => x.Token)
                .IsConcurrencyToken();

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
                    Id=1, EmpleadoId=1,EstaEliminado = false,EstaBloqueado = false,UserName = "juliamm1503",Password = "q39IYdrB8kwJq8u+DeDv0Q==",IdentificacionId = 1
                }
            };
        }
    }
}
