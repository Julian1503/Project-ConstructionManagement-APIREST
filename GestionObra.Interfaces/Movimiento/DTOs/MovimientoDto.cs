using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.Movimiento.DTOs
{
    public class MovimientoDto : DtoBase
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
