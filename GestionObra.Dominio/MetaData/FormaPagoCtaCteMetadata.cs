using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class FormaPagoCtaCteMetadata : IEntityTypeConfiguration<FormaPagoCtaCte>
    {
        public void Configure(EntityTypeBuilder<FormaPagoCtaCte> builder)
        {
           builder.ToTable("FormaPagoCtaCte");

            builder.Property(x => x.CustomerId)
                .IsRequired();
        }
    }
}
