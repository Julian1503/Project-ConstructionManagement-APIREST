using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
   public class PrecioMetadata : IEntityTypeConfiguration<Precio>
    {
        public void Configure(EntityTypeBuilder<Precio> builder)
        {
            builder.Property(x => x.MaterialId)
                .IsRequired();

            builder.Property(x => x.UsuarioId)
                .IsRequired();

            builder.Property(x => x.PrecioCompra)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.FechaActualizacion)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
