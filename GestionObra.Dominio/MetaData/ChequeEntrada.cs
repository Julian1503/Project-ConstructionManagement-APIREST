using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GestionObra.Dominio.MetaData
{
    public class ChequeEntradaMetadata : IEntityTypeConfiguration<ChequeEntrada>
    {
        public void Configure(EntityTypeBuilder<ChequeEntrada> builder)
        {
            builder.Property(x => x.EmitidoPor)
                .HasMaxLength(250)
                .IsRequired(false);

            builder.Property(x => x.Descontado)
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