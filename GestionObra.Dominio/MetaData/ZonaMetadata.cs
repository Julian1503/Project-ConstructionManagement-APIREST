using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class ZonaMetadata : IEntityTypeConfiguration<Zona>
    {
        public void Configure(EntityTypeBuilder<Zona> builder)
        {
            builder.Property(x => x.Descripcion)
                .HasField("_descripcion")
                .HasMaxLength(250)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
