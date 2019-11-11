using GestionObra.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class ComprobanteCompraModel
    {
        public decimal Monto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public decimal Percepciones { get; set; }
        public decimal Recargos { get; set; }
        public decimal Retenciones { get; set; }
        public bool Pagado { get; set; }
        public TipoPago TipoPago { get; set; }
        public long? ProveedorId { get; set; }
        public EstadoCompra EstadoCompra { get; set; }
        public long? ObraId { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroCompra { get; set; }
        public decimal Pagando { get; set; }
        public string Cuit { get; set; }
        public string Descripcion { get; set; }
        public int? NumeroCompronte { get; set; }
        public int? Cae { get; set; }

    }
}
