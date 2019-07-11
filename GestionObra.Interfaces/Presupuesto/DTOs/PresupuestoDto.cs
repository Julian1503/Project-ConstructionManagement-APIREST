using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.Presupuesto.DTOs
{
    public class PresupuestoDto : DtoBase
    {
        public decimal ImprevistoPesos { get; set; }
        public decimal ImprevistoPorcentual { get; set; }
        public EstadoPresupuesto EstadoPresupuesto { get; set; }
    }
}
