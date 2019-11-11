using GestionObra.Constantes;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.CuentaCorriente.DTOs;
using System;

namespace GestionObra.Interfaces.Operacion.DTOs
{
    public class OperacionDto : DtoBase
    {
        public long CuentaCorrienteId { get; set; }
        public CuentaCorrienteDto CuentaCorriente { get; set; }
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public TipoOperacion TipoOperacion { get; set; }
        public long Referencia { get; set; }
        public decimal? Descontado { get; set; }
        public string DePara { get; set; }
        public string Concepto { get; set; }
        public string CodigoCausal { get; set; }
        public DateTime? FechaEmision { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string ReferenciaPlus { get; set; }
        public bool EstaEnResumen { get; set; }
    }
}
