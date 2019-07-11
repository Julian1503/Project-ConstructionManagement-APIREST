using System.Collections.Generic;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class DescripcionTareaMetadata : IEntityTypeConfiguration<DescripcionTarea>
    {
        public void Configure(EntityTypeBuilder<DescripcionTarea> builder)
        {
            //builder.HasData(Seed());

            builder.Property(x => x.Descripcion)
                .HasMaxLength(250)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }

        //private List<DescripcionTarea> Seed()
        //{

        //}
    }
}
