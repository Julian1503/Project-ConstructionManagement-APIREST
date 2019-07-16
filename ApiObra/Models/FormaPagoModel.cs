using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObra.Constantes;

namespace ApiObra.Models
{
    public class FormaPagoModel
    {
        public long ComprobanteId { get; set; }
        public TipoPago TipoFormaPago { get; set; }
        public decimal Monto { get; set; }
    }
}
