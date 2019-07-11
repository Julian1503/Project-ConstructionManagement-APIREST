using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class RubroMetadata:IEntityTypeConfiguration<Rubro>
    {
        public void Configure(EntityTypeBuilder<Rubro> builder)
        {
            builder.HasData(Seek());

            builder.Property(x => x.Descripcion)
                .HasMaxLength(250)
                .IsRequired();
            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
        
        private List<Rubro> Seek()
        {
            return new List<Rubro>
            {
                new Rubro{Id = 1,Descripcion="Banco",TipoRubro = TipoRubro.Entrada},
                new Rubro{Id = 2,Descripcion="Cheque",TipoRubro = TipoRubro.Entrada},
                new Rubro{Id = 3,Descripcion="Devolucion",TipoRubro = TipoRubro.Entrada},
                new Rubro{Id = 4,Descripcion="Inversión",TipoRubro = TipoRubro.Entrada},
                new Rubro{Id = 5,Descripcion="Otro",TipoRubro = TipoRubro.Entrada},
                new Rubro{Id = 6,Descripcion="Préstamo",TipoRubro = TipoRubro.Entrada},
                new Rubro{Id = 7,Descripcion="Ventas",TipoRubro = TipoRubro.Entrada},
                new Rubro{Id = 8,Descripcion="Anticipos",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 9,Descripcion="Anticipos Administración",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 10,Descripcion="Contratistas",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 11,Descripcion="Depósito",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 12,Descripcion="Gastos Administrativos",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 13,Descripcion="Gastos Varios",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 14,Descripcion="Honorarios Administración",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 15,Descripcion="Honorarios Terceros",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 16,Descripcion="Impuestos",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 17,Descripcion="Limpieza Administración",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 18,Descripcion="Limpieza Taller",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 19,Descripcion="Mantenimiento",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 20,Descripcion="Materiales",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 21,Descripcion="Préstamo",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 22,Descripcion=" Refrigerios Administración",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 23,Descripcion=" Refrigerios Comercial",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 24,Descripcion=" Refrigerios Obras",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 25,Descripcion="Repuestos",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 26,Descripcion="Salarios",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 27,Descripcion="Servicios",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 28,Descripcion="Vehículo",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 29,Descripcion="Viáticos Administración",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 30,Descripcion="Viáticos Comercial",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 31,Descripcion="Viáticos Taller",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 32,Descripcion="Alquiler",TipoRubro = TipoRubro.Salida},
                new Rubro{Id = 33,Descripcion="Otro",TipoRubro = TipoRubro.Salida},
            };
        }
        
    }
}
