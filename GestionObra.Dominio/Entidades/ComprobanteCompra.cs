using GestionObra.Constantes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
    public class ComprobanteCompra : EntityBase
    {
        public decimal Monto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public decimal Percepciones { get; set; }
        public decimal Recargos { get; set; }
        public decimal Retenciones { get; set; }
        public long? ProveedorId { get; set; }
        public long? ObraId { get; set; }
        public TipoPago TipoPago { get; set; }
        public DateTime Fecha { get; set; }
        public bool Pagado { get; set; }
        public EstadoCompra EstadoCompra { get; set; }
        public int NumeroCompra { get; set; }
        public string Cuit { get; set; }
        public string Descripcion { get; set; }
        public decimal Pagando { get; set; }
        public int? NumeroCompronte { get; set; }
        public int? Cae { get; set; }

        public virtual Obra Obra{ get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<DetalleComprobante> DetalleComprobantes { get; set; }
    }
}
