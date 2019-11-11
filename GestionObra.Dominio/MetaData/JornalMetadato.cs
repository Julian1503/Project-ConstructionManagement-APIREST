using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
   public class JornalMetadato : IEntityTypeConfiguration<Jornal>
    {
        public void Configure(EntityTypeBuilder<Jornal> builder)
        {
            builder.Property(x => x.ObraId)
                .IsRequired();
            builder.Property(x => x.DiaJornal)

               .IsRequired();
            builder.Property(x => x.NumeroOrden)
               .IsRequired();

            builder.Property(x => x.Viatico)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
