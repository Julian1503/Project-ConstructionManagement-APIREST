using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class MaterialMetadata : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.Property(x => x.Codigo)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.Descripcion)
                .IsRequired();

            builder.Property(x => x.Detalle)
                .HasMaxLength(3000)
                .IsRequired(false);

            builder.Property(x => x.TipoMaterial)
                .IsRequired();

            builder.Property(x => x.Path)
                .HasMaxLength(400)
                .IsRequired(false);

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
