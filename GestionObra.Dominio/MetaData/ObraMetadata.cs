using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class ObraMetadata : IEntityTypeConfiguration<Obra>
    {
        public void Configure(EntityTypeBuilder<Obra> builder)
        {
            builder.Property(x => x.EncargadoId)
                .IsRequired();

            builder.Property(x => x.ZonaId)
                .IsRequired(false);

            builder.Property(x => x.PropietarioId)
                .IsRequired();

            builder.Property(x => x.FechaEstimadaInicio)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.Codigo)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Observiacion)
                .HasMaxLength(4000)
                .IsRequired();

            builder.Property(x => x.Descripcion)
                .HasMaxLength(250)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
