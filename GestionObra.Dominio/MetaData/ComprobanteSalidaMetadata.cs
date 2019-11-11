using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class ComprobanteSalidaMetadata : IEntityTypeConfiguration<ComprobanteSalida>
    {
        public void Configure(EntityTypeBuilder<ComprobanteSalida> builder)
        {
            builder.Property(x => x.SubRubroId)
                 .IsRequired();
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

            builder.Property(x => x.NumeroComprobante)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);

            builder.ToTable("ComprobanteSalida");
            builder.Property(x => x.TipoComprobanteSalida)
                .IsRequired();
        }
    }
}
