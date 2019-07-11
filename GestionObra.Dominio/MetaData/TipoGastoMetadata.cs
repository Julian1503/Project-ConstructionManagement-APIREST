using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class TipoGastoMetadata : IEntityTypeConfiguration<TipoGasto>
    {
        public void Configure(EntityTypeBuilder<TipoGasto> builder)
        {
            builder.Property(x => x.Descripcion)
                .HasMaxLength(250)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
