using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class ProveedorMetadato : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.Property(x => x.RazonSocial)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Contacto)
               .HasMaxLength(250)
               .IsRequired();

            builder.Property(x => x.CondicionIvaId)
             .IsRequired();

            builder.Property(x => x.Telefono)
               .HasMaxLength(30)
               .IsRequired();

            builder.Property(x => x.Email)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(x => x.Cuit)
            .HasMaxLength(12)
            .IsRequired();

            builder.Property(x => x.NombreFantasia)
        .HasMaxLength(250)
        .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado==false);
        }
    }
}
