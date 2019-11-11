using System;
using System.Collections.Generic;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class CategoriaMetadata : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasData(Seed());
            builder.Property(x => x.Descripcion)
                .HasField("_descripcion")
                .HasMaxLength(250)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }

        private List<Categoria> Seed()
        {
            return new List<Categoria>
            {
                new Categoria{Descripcion="Auxiliar",Id=1,EstaEliminado=false}
            };
        }
    }
}
