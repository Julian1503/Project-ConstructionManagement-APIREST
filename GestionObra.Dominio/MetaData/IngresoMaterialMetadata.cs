using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class IngresoMaterialMetadata:IEntityTypeConfiguration<IngresoMaterial>
    {
        public void Configure(EntityTypeBuilder<IngresoMaterial> builder)
        {
            builder.Property(x => x.Cantidad)
                .IsRequired();

            builder.Property(x => x.FechaIngreso)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.MaterialId)
                .IsRequired();

            builder.Property(x => x.ObraId)
                .IsRequired();

            builder.Property(x => x.EncargadoId)
                .IsRequired();

            builder.Property(x => x.CantidadDevuelta)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
