using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class ComprobanteModel
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
