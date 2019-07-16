using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObra.Constantes;

namespace ApiObra.Models
{
    public class PresupuestoModel
    {
        public DateTime FechaPresupuesto { get; set; }
        public decimal ImprevistoPesos { get; set; }
        public decimal ImprevistoPorcentual { get; set; }
        public EstadoPresupuesto EstadoPresupuesto { get; set; }
    }
}
