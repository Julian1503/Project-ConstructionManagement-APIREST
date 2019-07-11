using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class EmpresaMetadata:IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.Property(x => x.CondicionIvaId)
                .IsRequired(false);

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
