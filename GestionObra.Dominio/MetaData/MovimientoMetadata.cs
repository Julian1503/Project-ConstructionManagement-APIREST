using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class MovimientoMetadata : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> builder)
        {
            builder.Property(x => x.CajaId)
                .IsRequired();

            builder.Property(x => x.ComprobanteId)
                .IsRequired();

            builder.Property(x => x.UsuarioId)
                .IsRequired();

            builder.Property(x => x.Descripcion)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.FechaMovimiento)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.Monto)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.TipoMovimento)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
