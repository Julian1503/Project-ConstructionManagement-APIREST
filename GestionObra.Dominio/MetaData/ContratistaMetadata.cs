using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class ContratistaMetadata : IEntityTypeConfiguration<Contratista>
    {
        public void Configure(EntityTypeBuilder<Contratista> builder)
        {

            builder.Property(x => x.Cuit)
                .IsRequired(false);

            builder.Property(x => x.Path)
                .HasMaxLength(250)
                .IsRequired(false);

            builder.Property(x => x.Mail)
                .HasMaxLength(60)
                .IsRequired(false);

            builder.Property(x => x.NombreFantasia)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.RazonSocial)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Telefono)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.Sucursal)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
