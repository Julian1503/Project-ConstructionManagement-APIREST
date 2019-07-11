using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
   public class CuentaCorrienteMetadata : IEntityTypeConfiguration<CuentaCorriente>
    {
        public void Configure(EntityTypeBuilder<CuentaCorriente> builder)
        {
            builder.Property(x => x.BancoId)
                .IsRequired();

            builder.Property(x => x.ClienteId)
                .IsRequired();

            builder.Property(x => x.ComprobanteId)
                .IsRequired();

            builder.Property(x=>x.TotalVendido)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.FechaEmision)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.FechaVencimiento)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.TotalCobrado)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
