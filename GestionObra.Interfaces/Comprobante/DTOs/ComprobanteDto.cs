using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.Comprobante.DTOs
{
    public class ComprobanteDto : DtoBase
    {
        public string Descripcion { get; set; }
        public long EmpresaId { get; set; }
        public long UsuarioId { get; set; }
        public long RubroId { get; set; }
        public decimal Descuento { get; set; }
        public decimal Monto { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroComprobante { get; set; }
    }
}
