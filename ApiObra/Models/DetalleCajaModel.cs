using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObra.Constantes;

namespace ApiObra.Models
{
    public class DetalleCajaModel
    {
        public long CajaId { get; set; }
        public decimal Monto { get; set; }
        public TipoPago TipoPago { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
    }
}
