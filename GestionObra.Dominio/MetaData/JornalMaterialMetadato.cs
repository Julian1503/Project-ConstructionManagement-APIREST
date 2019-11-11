using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class JornalMaterialMetadato : IEntityTypeConfiguration<JornalMaterial>
    {
        public void Configure(EntityTypeBuilder<JornalMaterial> builder)
        {
            builder.Property(x => x.JornalId).IsRequired();
            builder.Property(x => x.MaterialId).IsRequired();
            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
