using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GestionObra.Dominio.MetaData
{
    public class DetalleCajaMetadata : IEntityTypeConfiguration<DetalleCaja>
    {
        public void Configure(EntityTypeBuilder<DetalleCaja> builder)
        {
            builder.Property(x => x.CajaId)
                .IsRequired();

            builder.Property(x => x.Monto)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.TipoPago)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
