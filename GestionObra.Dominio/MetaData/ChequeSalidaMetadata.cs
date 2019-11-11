using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class ChequeSalidaMetadata : IEntityTypeConfiguration<ChequeSalida>
    {
        public void Configure(EntityTypeBuilder<ChequeSalida> builder)
        {
            builder.Property(x => x.PagueseA)
                .HasMaxLength(250)
                 .IsRequired();

            builder.Property(x => x.BancoId)
               .IsRequired();

            builder.Property(x => x.FechaDesde)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.FechaHasta)
               .HasColumnType("DateTime")
               .IsRequired();

            builder.Property(x => x.Monto)
               .IsRequired();

            builder.Property(x => x.Concepto)
               .HasMaxLength(250)
               .IsRequired(false);

            builder.Property(x => x.Numero)
        .IsRequired();

            builder.Property(x => x.Serie)
        .IsRequired();

            builder.HasQueryFilter(x => !x.EstaEliminado);
        }
    }
}
