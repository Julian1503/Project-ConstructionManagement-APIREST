using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionObra.Dominio.MetaData
{
    public class DetalleComprobanteMetadata : IEntityTypeConfiguration<DetalleComprobante>
    {
        public void Configure(EntityTypeBuilder<DetalleComprobante> builder)
        {
            builder.Property(x => x.Cantidad)
                .IsRequired();

            builder.Property(x => x.Codigo)
                .IsRequired();

            builder.Property(x => x.SubTotal)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.Descripcion)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.PrecioUnitario)
                .HasColumnType("Numeric")
                .IsRequired();

            builder.Property(x => x.ComprobanteId)
                .IsRequired();

            builder.HasQueryFilter(x => x.EstaEliminado == false);
        }
    }
}
