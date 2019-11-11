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
            builder.Property(x => x.Numero)
                .IsRequired();

            builder.Property(x => x.Descripcion)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.FechaPresupuesto)
                .HasColumnType("DateTime")
                .IsRequired();
            builder.Property(x => x.ImprevistoPorcentual)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.PrecioCliente)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.Beneficio)
               .HasColumnType("Numeric")
               .IsRequired();

            builder.Property(x => x.Impuestos)
               .HasColumnType("Numeric")
               .IsRequired();
            builder.Property(x => x.SubTotal)
              .HasColumnType("Numeric")
              .IsRequired();

            builder.Property(x => x.EmpresaId)
               .IsRequired();
            builder.Property(x => x.ObraId)
         .IsRequired();
            builder.Property(x => x.EstadoPresupuesto)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
