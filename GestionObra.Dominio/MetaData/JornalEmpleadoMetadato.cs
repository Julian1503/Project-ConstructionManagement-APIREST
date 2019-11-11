using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class JornalEmpleadoMetadato : IEntityTypeConfiguration<ObraEmpleado>
    {
        public void Configure(EntityTypeBuilder<ObraEmpleado> builder)
        {
            builder.Property(x => x.ObraId).IsRequired();
            builder.Property(x => x.EmpleadoId).IsRequired();
            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
