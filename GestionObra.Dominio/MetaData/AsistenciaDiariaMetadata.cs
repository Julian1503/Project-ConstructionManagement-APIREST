using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class AsistenciaDiariaMetadata : IEntityTypeConfiguration<AsistenciaDiaria>
    {
        public void Configure(EntityTypeBuilder<AsistenciaDiaria> builder)
        {
            builder.Property(x => x.Asistio)
                .IsRequired();

            builder.Property(x => x.CausaId)
                .IsRequired(false);

            builder.Property(x => x.EmpleadoId)
                .IsRequired();

            builder.Property(x => x.JornalId)
                .IsRequired();

            builder.Property(x => x.Observacion)
                .HasMaxLength(250)
              .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
