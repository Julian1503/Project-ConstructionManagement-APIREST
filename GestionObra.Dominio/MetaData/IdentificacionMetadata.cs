using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class IdentificacionMetadata : IEntityTypeConfiguration<Identificacion>
    {
        public void Configure(EntityTypeBuilder<Identificacion> builder)
        {
            builder.HasData(Seed());
        }

        private List<Identificacion> Seed()
        {
            return new List<Identificacion>
            {
                new Identificacion { Administracion=true,Configuracion=true,Obra=true,Tesoreria=true,Usuarios=true,Id=1}
            };
        }
    }
}
