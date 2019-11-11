using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class CajaMetadata:IEntityTypeConfiguration<Caja>
    {
        public void Configure(EntityTypeBuilder<Caja> builder)
        {
            builder.Property(x => x.Diferencia)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.MontoSistema)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.UsuarioAperturaId)
                .IsRequired();

            builder.Property(x => x.FechaApertura)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.FechaCierre)
                .HasColumnType("DateTime")
                .IsRequired(false);

            builder.Property(x => x.UsuarioCierreId)
                .IsRequired(false);
        }
    }
}
