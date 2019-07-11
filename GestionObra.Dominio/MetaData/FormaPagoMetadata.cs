using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class FormaPagoMetadata:IEntityTypeConfiguration<FormaPago>
    {
        public void Configure(EntityTypeBuilder<FormaPago> builder)
        {
            builder.Property(x => x.ComprobanteId)
                .IsRequired();

            builder.Property(x => x.Monto)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.TipoFormaPago)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
