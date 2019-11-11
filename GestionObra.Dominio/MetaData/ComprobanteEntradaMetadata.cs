using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class ComprobanteEntradaMetadata : IEntityTypeConfiguration<ComprobanteEntrada>
    {
        public void Configure(EntityTypeBuilder<ComprobanteEntrada> builder)
        {
          
            builder.Property(x => x.UsuarioId)
                .IsRequired();

            builder.Property(x => x.Detalle)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(x => x.Monto)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.Fecha)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.TipoComprobanteEntrada)
                .IsRequired();
            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
