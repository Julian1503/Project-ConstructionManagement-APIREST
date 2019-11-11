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
                new Rubro{Id = 1,Codigo=4100000,Descripcion="Ingreso por ventas",TipoRubro = TipoRubro.Ingreso},
                new Rubro{Id = 2,Codigo=4200000,Descripcion="Ingreso financiero",TipoRubro = TipoRubro.Ingreso},
                new Rubro{Id = 3,Codigo=4300000,Descripcion="Otros Ingresos" ,TipoRubro = TipoRubro.Ingreso},
                new Rubro{Id = 4,Codigo=550000,Descripcion="Produccion",TipoRubro = TipoRubro.Egreso},
                new Rubro{Id = 5,Codigo=5600000,Descripcion="Vehiculos y maquinaria",TipoRubro = TipoRubro.Egreso},
                new Rubro{Id = 6,Codigo=5700000,Descripcion="Administracion",TipoRubro = TipoRubro.Egreso},
                new Rubro{Id = 7,Codigo=5800000,Descripcion="Comericalizacion",TipoRubro = TipoRubro.Egreso},
                new Rubro{Id = 8,Codigo=5900000,Descripcion="Egreso financieros",TipoRubro = TipoRubro.Egreso},
                new Rubro{Id = 9,Codigo=6000000,Descripcion="Otros Egresos",TipoRubro = TipoRubro.Egreso},
                new Rubro{Id = 10,Codigo=1100000,Descripcion="Activo Corriente",TipoRubro = TipoRubro.Activo},
                new Rubro{Id = 11,Codigo=1200000,Descripcion="Activo No Corriente",TipoRubro = TipoRubro.Activo},
                new Rubro{Id = 12,Codigo=2100000,Descripcion="Activo No Corriente",TipoRubro = TipoRubro.Activo},
                new Rubro{Id = 13,Codigo=2200000,Descripcion="Deudas Comerciales",TipoRubro = TipoRubro.Pasivo},
                new Rubro{Id = 14,Codigo=2300000,Descripcion="Deudas Bancarias",TipoRubro = TipoRubro.Pasivo},
                new Rubro{Id = 15,Codigo=2400000,Descripcion="Deudas Financieras",TipoRubro = TipoRubro.Pasivo},
                new Rubro{Id = 16,Codigo=2500000,Descripcion="Deudas Sociales",TipoRubro = TipoRubro.Pasivo},
                new Rubro{Id = 17,Codigo=2600000,Descripcion="Otras Deudas Fiscales",TipoRubro = TipoRubro.Pasivo},
                new Rubro{Id = 18,Codigo=3100000,Descripcion="Capital Social",TipoRubro = TipoRubro.PatrimonioNeto},
                new Rubro{Id = 19,Codigo=3200000,Descripcion="Reservas",TipoRubro = TipoRubro.PatrimonioNeto},
                new Rubro{Id = 20,Codigo=3300000,Descripcion="Resultado No Asignado",TipoRubro = TipoRubro.PatrimonioNeto},
            };
        }
        
    }
}
