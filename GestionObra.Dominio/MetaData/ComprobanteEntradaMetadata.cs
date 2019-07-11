using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class ComprobanteEntradaMetadata : IEntityTypeConfiguration<ComprobanteEntrada>
    {
        public void Configure(EntityTypeBuilder<ComprobanteEntrada> builder)
        {
            builder.Property(x => x.TipoComprobanteEntrada)
                .IsRequired();
        }
    }
}
