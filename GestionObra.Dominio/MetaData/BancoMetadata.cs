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
                .HasMaxLength(250)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }

        private List<Banco> Seed()
        {
            return new List<Banco>
            {
                new Banco{Id=1,Descripcion="Banco Macro"},
                new Banco{Id=2,Descripcion="Banco Nacion"},
                new Banco{Id=3,Descripcion="ICBC"},
                new Banco{Id=4,Descripcion="BBVA"},
                new Banco{Id=5,Descripcion="Galicia"},
                new Banco{Id=6,Descripcion="Santander Rio"}
            };
        }
    }
}
