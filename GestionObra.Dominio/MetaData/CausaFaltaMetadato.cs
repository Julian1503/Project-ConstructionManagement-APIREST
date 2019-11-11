using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
   public class CausaFaltaMetadato : IEntityTypeConfiguration<CausaFalta>
    {
        public void Configure(EntityTypeBuilder<CausaFalta> builder)
        {
            builder.Property(x => x.Descripcion)
                 .HasField("_descripcion")
                .HasMaxLength(250)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
