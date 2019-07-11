using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
   public class StockMetadata : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.Property(x => x.UsuarioId)
                .IsRequired();

            builder.Property(x => x.MaterialId)
                .IsRequired();

            builder.Property(x => x.FechaActualizacion)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.StockActual)
                .IsRequired();

            builder.Property(x => x.StockMinimo)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
