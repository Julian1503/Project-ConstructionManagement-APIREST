using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
   public class TareaMetadata : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            builder.Property(x => x.DescripcionTareaId)
                .IsRequired();

            builder.Property(x => x.ObraId)
                .IsRequired();

            builder.Property(x => x.Observacion)
                .HasMaxLength(4000)
                .IsRequired(false);

            builder.Property(x => x.Duracion)
                .HasColumnType("Time")
                .IsRequired();

            builder.Property(x => x.Estado)
                .IsRequired();

            builder.Property(x => x.NumeroOrden)
                .IsRequired();

            builder.Property(x => x.TiempoEmpleado)
                .HasColumnType("Time")
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
