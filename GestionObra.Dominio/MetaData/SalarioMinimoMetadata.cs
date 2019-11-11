using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class SalarioMinimoMetadata : IEntityTypeConfiguration<SalarioMinimo>
    {
        public void Configure(EntityTypeBuilder<SalarioMinimo> builder)
        {
            builder.Property(x => x.FechaActualizacion)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.Salario)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.HasQueryFilter(x => !x.EstaEliminado);
        }
    }
}
