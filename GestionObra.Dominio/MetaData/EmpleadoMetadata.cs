using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class EmpleadoMetadata : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasData(Seed());
            builder.Property(x => x.Apellido)
               .HasMaxLength(250)
               .IsRequired();

            builder.Property(x => x.Legajo)
             .IsRequired();

            builder.Property(x => x.Nombre)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.FechaNacimiento)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(x => x.CategoriaId)
               .IsRequired();

            builder.Property(x => x.FechaIncio)
               .IsRequired()
               .HasColumnType("DateTime");

            builder.Property(x => x.Dni)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(x => x.CUIT)
               .HasMaxLength(12)
               .IsRequired();

            builder.Property(x => x.Path)
              .IsRequired(false);

            builder.Property(x => x.Telefono)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.Celular)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }

        private List<Empleado> Seed()
        {
            return new List<Empleado>
            {
                new Empleado{ Apellido="Delgado", Nombre="Julian", Celular="3815451043" ,Telefono="3815451043" ,Dni="38154510",CUIT="3815451043" , CategoriaId=1,FechaIncio= new DateTime(2019,06,20), FechaNacimiento=new DateTime(1996,03,15),Path="",Legajo=1,Id=1,EstaEliminado=false }
            };
        }
    }
}
