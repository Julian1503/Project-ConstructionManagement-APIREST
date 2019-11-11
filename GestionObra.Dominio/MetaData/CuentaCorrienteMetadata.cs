using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
   public class CuentaCorrienteMetadata : IEntityTypeConfiguration<CuentaCorriente>
    {
        public void Configure(EntityTypeBuilder<CuentaCorriente> builder)
        {
            builder.HasData(Seed());
            builder.Property(x => x.BancoId)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }

        private List<CuentaCorriente> Seed()
        {
            return new List<CuentaCorriente>
            {
                new CuentaCorriente{Id=1, BancoId=1, MontoMaximo=3800000},
                new CuentaCorriente{Id=2, BancoId=2, MontoMaximo=3800000},
                new CuentaCorriente{Id=3, BancoId=3, MontoMaximo=3800000},
            };
        }
    }
}
