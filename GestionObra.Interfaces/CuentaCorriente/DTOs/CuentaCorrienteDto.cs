using System;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.CuentaCorriente.DTOs
{
    public class CuentaCorrienteDto : DtoBase
    {
        public long BancoId { get; set; }
        public long ClienteId { get; set; }
        public long ComprobanteId { get; set; }
        public decimal TotalVendido { get; set; }
        public decimal TotalCobrado { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
