using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class BancoMetadata : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.HasData(Seed());

            builder.Property(x => x.Descripcion)
                .HasField("_descripcion")
                .HasMaxLength(250);

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

        private List<Banco> Seed()
        {
            return new List<Banco>
            {
                new Banco{Id=1,Path=@"https://d1nzec96y7u1ro.cloudfront.net/wp-content/uploads/2017/10/24145915/macro_4-01.png",RazonSocial="Banco Macro",Cuit="12312321",Sucursal="Centro",NombreFantasia  ="Banco Macro", CBU="12312312312",Descripcion="",Telefono="1231231",Mail="asd"},
                new Banco{Id=2,Path=@"https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Logo_Banco_de_la_Nacion_Argentina.svg/500px-Logo_Banco_de_la_Nacion_Argentina.svg.png",RazonSocial="Banco Nacion",Cuit="12312321",Sucursal="Centro" ,NombreFantasia="Banco Nacion", CBU="12312312312",Descripcion="",Telefono="1231231",Mail="asd"},
                 new Banco{Id=3,Path="",RazonSocial="Valores a depositor",Cuit="Valores a depositor",Sucursal="Valores a depositor" ,NombreFantasia="Valores a depositor", CBU="Valores a depositor",Descripcion="Valores a depositor",Telefono="Valores a depositor",Mail="Valores a depositor"},
            };
        }
    }
}
