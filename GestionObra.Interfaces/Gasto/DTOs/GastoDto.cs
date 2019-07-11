using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.Gasto.DTOs
{
    public class GastoDto : DtoBase
    {
        public long TipoGastoId { get; set; }
        public decimal Monto { get; set; }
        public long PresupuestoId { get; set; }
    }
}
