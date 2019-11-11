using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Presupuesto.DTOs;
using GestionObra.Interfaces.TipoGasto.DTOs;

namespace GestionObra.Interfaces.Gasto.DTOs
{
    public class GastoDto : DtoBase
    {
        public long TipoGastoId { get; set; }
        public decimal Monto { get; set; }
        public long PresupuestoId { get; set; }
        public PresupuestoDto Presupuesto { get; set; }
        public TipoGastoDto TipoGasto { get; set; }
    }
}
