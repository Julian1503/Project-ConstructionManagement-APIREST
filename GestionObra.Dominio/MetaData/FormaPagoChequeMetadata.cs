using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
   public class FormaPagoChequeMetadata : IEntityTypeConfiguration<FormaPagoCheque>
    {
        public void Configure(EntityTypeBuilder<FormaPagoCheque> builder)
        {
            builder.ToTable("FormaPagoCheque");

            builder.Property(x => x.BancoId)
                .IsRequired();

            builder.Property(x => x.Numero)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.EnteEmisor)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.FechaEmision)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.Dias)
                .IsRequired();
        }
    }
}
