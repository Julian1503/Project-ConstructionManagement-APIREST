using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class OperacionMetadata : IEntityTypeConfiguration<Operacion>
    {
        public void Configure(EntityTypeBuilder<Operacion> builder)
        {
            builder.Property(x => x.ReferenciaPlus)
                .HasMaxLength(250).IsRequired();

            builder.Property(x => x.Referencia)
              .IsRequired();

            builder.Property(x => x.CodigoCausal)
                .HasMaxLength(250);

            builder.Property(x => x.CuentaCorrienteId)
               .IsRequired();

            builder.Property(x => x.Debe)
                .HasColumnType("Numeric");

            builder.Property(x => x.FechaEmision)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.FechaVencimiento)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.Haber)
                .HasColumnType("Numeric");
        }
    }
}
