using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class PresupuestoMetadata:IEntityTypeConfiguration<Presupuesto>
    {
        public void Configure(EntityTypeBuilder<Presupuesto> builder)
        {
            builder.Property(x => x.ImprevistoPorcentual)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.ImprevistoPesos)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.EstadoPresupuesto)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
