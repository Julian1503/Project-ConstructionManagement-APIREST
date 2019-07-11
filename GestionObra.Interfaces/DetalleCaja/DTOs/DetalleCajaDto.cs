using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.DetalleCaja.DTOs
{
    public class DetalleCajaDto : DtoBase
    {
        public long CajaId { get; set; }
        public decimal Monto { get; set; }
        public TipoPago TipoPago { get; set; }
    }
}
