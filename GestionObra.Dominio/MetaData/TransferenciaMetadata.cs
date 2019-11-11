﻿using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class TransferenciaMetadata : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.Property(x => x.Numero)
               .IsRequired();

            builder.Property(x => x.Fecha)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.Concepto)
               .HasMaxLength(250)
              .IsRequired();


            builder.Property(x => x.BancoId)
                .IsRequired();

            builder.Property(x => x.Usado)
                .IsRequired();
        }
    }
}
