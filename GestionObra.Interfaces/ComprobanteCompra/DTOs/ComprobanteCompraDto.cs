using GestionObra.Constantes;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Obra.DTOs;
using GestionObra.Interfaces.Proveedor.DTOs;
using GestionObra.Interfaces.SubRubro.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.ComprobanteCompra.DTOs
{
    public class ComprobanteCompraDto : DtoBase
    {
        public decimal Monto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public decimal Percepciones { get; set; }
        public EstadoCompra EstadoCompra { get; set; }
        public decimal Recargos { get; set; }
        public decimal Retenciones { get; set; }
        public TipoPago TipoPago { get; set; }
        public long? ProveedorId { get; set; }
        public long? ObraId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Pagado { get; set; }
        public int NumeroCompra { get; set; }
        public string Cuit { get; set; }
        public string Descripcion { get; set; }
        public decimal Pagando { get; set; }
        public int? NumeroCompronte { get; set; }
        public int? Cae { get; set; }
        public decimal Total => ((Monto - Descuento) + Recargos) + Retenciones + Iva + Percepciones;
  
        public virtual ObraDto Obra { get; set; }
        public virtual ProveedorDto Proveedor { get; set; }
    }
}
