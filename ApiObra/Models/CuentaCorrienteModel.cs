using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class CuentaCorrienteModel
    {
        public long BancoId { get; set; }
        public long ComprobanteId { get; set; }
        public decimal TotalVendido { get; set; }
        public decimal TotalCobrado { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
