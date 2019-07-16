using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObra.Constantes;

namespace ApiObra.Models
{
    public class MovimientoModel
    {
        public long CajaId { get; set; }
        public long UsuarioId { get; set; }
        public long ComprobanteId { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public TipoMovimiento TipoMovimento { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
    }
}
