using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.DetalleComprobante.DTOs
{
    public class DetalleComprobanteDto : DtoBase
    {
        public long ComprobanteId { get; set; }
        public string Codigo { get; set; }
        public long MaterialId { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
    }
}
