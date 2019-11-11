using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Caja.DTOs;

namespace GestionObra.Interfaces.DetalleCaja.DTOs
{
    public class DetalleCajaDto : DtoBase
    {
        public CajaDto Caja { get; set; }
        public long CajaId { get; set; }
        public decimal Monto { get; set; }
        public TipoPago TipoPago { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
    }
}
