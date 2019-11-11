using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace GestionObra.Dominio.MetaData
{
    public class ObraMetadata : IEntityTypeConfiguration<Obra>
    {
        public void Configure(EntityTypeBuilder<Obra> builder)
        {
            builder.HasData(Seed());

            builder.Property(x => x.EncargadoId)
                .IsRequired();

            builder.Property(x => x.ZonaId)
                .IsRequired(false);


            builder.Property(x => x.FechaEstimadaInicio)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.Codigo)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Observacion)
                .HasMaxLength(4000);

            builder.Property(x => x.Descripcion)
                .HasMaxLength(250)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }

        private List<Obra> Seed()
        {
            return new List<Obra>()
            {
                new Obra { Id = 1, Codigo = "", Descripcion = "Oficina" , EncargadoId = 1,PropietarioId = null,ZonaId=null,EstaEliminado=false,FechaEstimadaInicio = DateTime.Now},
                 new Obra { Id = 2, Codigo = "", Descripcion = "Taller" , EncargadoId = 1,PropietarioId = null,ZonaId=null,EstaEliminado=false ,FechaEstimadaInicio = DateTime.Now},
                  new Obra { Id = 3, Codigo = "Compras personales", Descripcion = "Alicia" , EncargadoId = 1,PropietarioId = null,ZonaId=null,EstaEliminado=false,FechaEstimadaInicio = DateTime.Now },
                    new Obra { Id = 4, Codigo = "Compras personales", Descripcion = "Carla" , EncargadoId = 1,PropietarioId = null,ZonaId=null,EstaEliminado=false,FechaEstimadaInicio = DateTime.Now },
                      new Obra { Id = 5, Codigo = "Compras personales", Descripcion = "Eduardo" , EncargadoId = 1,PropietarioId = null,ZonaId=null,EstaEliminado=false ,FechaEstimadaInicio = DateTime.Now},
                       new Obra { Id = 6, Codigo = "Compras personales", Descripcion = "Marcos" , EncargadoId = 1,PropietarioId = null,ZonaId=null,EstaEliminado=false ,FechaEstimadaInicio = DateTime.Now},
                        new Obra { Id = 7, Codigo = "Compras personales", Descripcion = "Pablo" , EncargadoId = 1,PropietarioId = null,ZonaId=null,EstaEliminado=false ,FechaEstimadaInicio = DateTime.Now},
                         new Obra { Id = 8, Codigo = "Compras personales", Descripcion = "Raul" , EncargadoId = 1,PropietarioId = null,ZonaId=null,EstaEliminado=false ,FechaEstimadaInicio = DateTime.Now},
                         new Obra { Id = 9, Codigo = "", Descripcion = "Otros" , EncargadoId = 1,PropietarioId = null,ZonaId=null,EstaEliminado=false,FechaEstimadaInicio = DateTime.Now },
            };
        }
    }
}
