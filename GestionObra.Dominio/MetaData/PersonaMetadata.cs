using System.Collections.Generic;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class PersonaMetadata : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            //TODO
            //builder.HasData(Seed());
            builder.Property(x => x.Apellido)
                .HasField("_apellido")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Nombre)
                .HasField("_nombre")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.FechaNacimiento)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(x => x.Dni)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(x => x.Telefono)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.Celular)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Sexo)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
        //TODO
        //private List<Persona> Seed()
        //{
        //    return null;
        //}
    }
}
