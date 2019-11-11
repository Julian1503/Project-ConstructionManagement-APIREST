using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class AsistenciaContratistaMetadata : IEntityTypeConfiguration<AsistenciaContratista>
    {
        public void Configure(EntityTypeBuilder<AsistenciaContratista> builder)
        {

            builder.Property(x => x.ContratistaId)
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
