using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.MetaData
{
    public class SubRubroMetadata : IEntityTypeConfiguration<SubRubro>
    {
        public void Configure(EntityTypeBuilder<SubRubro> builder)
        {
            builder.HasData(Seed());
        }

        private List<SubRubro> Seed()
        {
            return new List<SubRubro>
            {
                new SubRubro { Id=1,Codigo = 410100, Descripcion="Ingresos por Obra",RubroId=1},
                new SubRubro { Id=2,Codigo = 410200, Descripcion="Ingresos por alquiler de grua",RubroId=1},
                new SubRubro { Id=3,Codigo = 410300, Descripcion="Ingresos por venta de materiales",RubroId=1},
                new SubRubro { Id=4,Codigo = 420100, Descripcion="Intereses plazo fijo",RubroId=2},
                new SubRubro { Id=5,Codigo = 430100, Descripcion="Reintegro ART",RubroId=3},
                new SubRubro { Id=6,Codigo = 430200, Descripcion="Venta Bs de Uso",RubroId=3},
                new SubRubro { Id=7,Codigo = 5510100, Descripcion="Materiales Utilizados",RubroId=4},
                new SubRubro { Id=8,Codigo = 5510200, Descripcion="Personal de Produccion",RubroId=4},
                new SubRubro { Id=9,Codigo = 5510300, Descripcion="Cargas Sociales Personal de Produccion",RubroId=4},
                new SubRubro { Id=10,Codigo = 5510400, Descripcion="Honorarios Directos, Tec. Profesionales",RubroId=4},
                new SubRubro { Id=11,Codigo = 5510500, Descripcion="Servicios de Terceros",RubroId=4},
                new SubRubro { Id=12,Codigo = 5510600, Descripcion="Fletes",RubroId=4},
                new SubRubro { Id=13,Codigo = 5510700, Descripcion="Equipo de Trabajo",RubroId=4},
                new SubRubro { Id=14,Codigo = 5510800, Descripcion="Refrigerio de Obras",RubroId=4},
                new SubRubro { Id=15,Codigo = 5510900, Descripcion="Seguros del Personal",RubroId=4},
                new SubRubro { Id=16,Codigo = 5511000, Descripcion="Gastos Generales",RubroId=4},
                new SubRubro { Id=17,Codigo = 5511100, Descripcion="Peajes",RubroId=4},
                new SubRubro { Id=19,Codigo = 5511200, Descripcion="Gastos de Viaje",RubroId=4},
                new SubRubro { Id=20,Codigo = 5511300, Descripcion="Permisos Municipales",RubroId=4},
                new SubRubro { Id=21,Codigo = 5511400, Descripcion="Seguros de Caucion",RubroId=4},
                new SubRubro { Id=22,Codigo = 5511500, Descripcion="Bienes Consumibles en obra",RubroId=4},
                new SubRubro { Id=23,Codigo = 5610100, Descripcion="Combustible",RubroId=5},
                new SubRubro { Id=24,Codigo = 5610200, Descripcion="Aceite y lubricantes",RubroId=5},
                new SubRubro { Id=25,Codigo = 5610300, Descripcion="Repuestos y reparaciones",RubroId=5},
                new SubRubro { Id=26,Codigo = 5610400, Descripcion="Seguros Automotores",RubroId=5},
                new SubRubro { Id=27,Codigo = 5710100, Descripcion="Honorarios Administracion",RubroId=6},
                new SubRubro { Id=28,Codigo = 5710200, Descripcion="Honorarios Contables",RubroId=6},
                new SubRubro { Id=29,Codigo = 5710300, Descripcion="Sueldos Administracion",RubroId=6},
                new SubRubro { Id=30,Codigo = 5710400, Descripcion="Cargas Sociales Administracion",RubroId=6},
                new SubRubro { Id=31,Codigo = 5710500, Descripcion="Luz",RubroId=6},
                new SubRubro { Id=32,Codigo = 5710600, Descripcion="Telefono",RubroId=6},
                new SubRubro { Id=33,Codigo = 5710700, Descripcion="Gas",RubroId=6},
                new SubRubro { Id=34,Codigo = 5710800, Descripcion="Agua",RubroId=6},
                new SubRubro { Id=35,Codigo = 5710900, Descripcion="Servicio de Internet",RubroId=6},
                new SubRubro { Id=36,Codigo = 5711000, Descripcion="Papeleria, Impresos y Utiles",RubroId=6},
                new SubRubro { Id=37,Codigo = 5711100, Descripcion="Gastos de Refrigerio",RubroId=6},
                new SubRubro { Id=38,Codigo = 5711300, Descripcion="Gastos de Representacion",RubroId=6},
                new SubRubro { Id=39,Codigo = 5711400, Descripcion="Gastos de Viaje",RubroId=6},
                new SubRubro { Id=40,Codigo = 5711500, Descripcion="Gastos de Movilidad",RubroId=6},
                new SubRubro { Id=41,Codigo = 5711600, Descripcion="Seguros",RubroId=6},
                new SubRubro { Id=42,Codigo = 5711700, Descripcion="Franqueo",RubroId=6},
                new SubRubro { Id=43,Codigo = 5711800, Descripcion="Estacionamiento",RubroId=6},
                new SubRubro { Id=44,Codigo = 5711900, Descripcion="Gastos Judiciales",RubroId=6},
                new SubRubro { Id=45,Codigo = 5712000, Descripcion="Gastos Generales",RubroId=6},
                new SubRubro { Id=46,Codigo = 5712100, Descripcion="Combustible",RubroId=6},
                new SubRubro { Id=47,Codigo = 5712200, Descripcion="Sellados y permisos municipales",RubroId=6},
                new SubRubro { Id=48,Codigo = 5712300, Descripcion="Servicios de terceros",RubroId=6},
                new SubRubro { Id=49,Codigo = 5712400, Descripcion="IERIC - Insc. anual y tarjetas",RubroId=6},
                new SubRubro { Id=50,Codigo = 5712500, Descripcion="Alquileres",RubroId=6},
                new SubRubro { Id=51,Codigo = 5712600, Descripcion="Mantenimeinto y limpieza",RubroId=6},
                new SubRubro { Id=52,Codigo = 5712700, Descripcion="Fletes",RubroId=6},
                new SubRubro { Id=53,Codigo = 5712800, Descripcion="Multas impositivas",RubroId=6},
                new SubRubro { Id=54,Codigo = 5712900, Descripcion="Gastos de Leasing",RubroId=6},
                new SubRubro { Id=55,Codigo = 5800100, Descripcion="Honorarios Comerciales",RubroId=7},
                new SubRubro { Id=56,Codigo = 5800200, Descripcion="Publicidad y propaganda",RubroId=7},
                new SubRubro { Id=57,Codigo = 5800300, Descripcion="Gastos de Representacion",RubroId=7},
                new SubRubro { Id=58,Codigo = 5800400, Descripcion="Gastos de Viaje",RubroId=7},
                new SubRubro { Id=59,Codigo = 5800500, Descripcion="Donaciones",RubroId=7},
                new SubRubro { Id=60,Codigo = 5800700, Descripcion="Combustible",RubroId=7},
                new SubRubro { Id=61,Codigo = 5800600, Descripcion="Obsequios Empresariales",RubroId=7},
                new SubRubro { Id=62,Codigo = 5900100, Descripcion="Comisiones y gastos bancarios",RubroId=8},
                new SubRubro { Id=63,Codigo = 5900200, Descripcion="Impuestos al deb y cred bancarios",RubroId=8},
                new SubRubro { Id=64,Codigo = 5900300, Descripcion="Interes Bancario",RubroId=8},
                new SubRubro { Id=65,Codigo = 5900400, Descripcion="Interes y act. Org. Oficiales",RubroId=8},
                new SubRubro { Id=66,Codigo = 5900500, Descripcion="Redondeo",RubroId=8},
                new SubRubro { Id=67,Codigo = 5900600, Descripcion="Intereses Comerciales",RubroId=8},
            };
        }
    }
}
