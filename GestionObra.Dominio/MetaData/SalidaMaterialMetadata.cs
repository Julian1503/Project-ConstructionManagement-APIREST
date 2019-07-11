using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class SalidaMaterialMetadata : IEntityTypeConfiguration<SalidaMaterial>
    {
        public void Configure(EntityTypeBuilder<SalidaMaterial> builder)
        {
            builder.Property(x => x.DeObraId)
                .IsRequired();

            builder.Property(x => x.ParaObraId)
                .IsRequired();

            builder.Property(x => x.ResponsableId)
                .IsRequired();

            builder.Property(x => x.MaterialId)
                .IsRequired();

            builder.Property(x => x.FechaEgreso)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.Cantidad)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
