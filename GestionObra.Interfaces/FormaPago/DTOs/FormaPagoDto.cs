using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.FormaPago.DTOs
{
    public class FormaPagoDto : DtoBase
    {
        public long ComprobanteId { get; set; }
        public TipoPago TipoFormaPago { get; set; }
        public decimal Monto { get; set; }
    }
}
