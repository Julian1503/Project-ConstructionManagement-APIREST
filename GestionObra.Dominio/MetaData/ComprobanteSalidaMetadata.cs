using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class ComprobanteSalidaMetadata : IEntityTypeConfiguration<ComprobanteSalida>
    {
        public void Configure(EntityTypeBuilder<ComprobanteSalida> builder)
        {
            builder.Property(x => x.TipoComprobanteSalida)
                .IsRequired();

            builder.Property(x => x.Perioricidad)
                .IsRequired();
        }
    }
}
