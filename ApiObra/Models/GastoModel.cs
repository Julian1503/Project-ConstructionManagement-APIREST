using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class GastoModel
    {
        public long TipoGastoId { get; set; }
        public decimal Monto { get; set; }
        public long PresupuestoId { get; set; }
    }
}
