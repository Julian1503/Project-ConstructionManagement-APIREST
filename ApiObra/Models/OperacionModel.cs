using GestionObra.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class OperacionModel
    {
        public long CuentaCorrienteId { get; set; }
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public long Referencia { get; set; }
        public TipoOperacion TipoOperacion { get; set; }
        public string CodigoCausal { get; set; }
        public decimal? Descontado { get; set; }
        public string DePara { get; set; }
        public string Concepto { get; set; }
        public DateTime? FechaEmision { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string ReferenciaPlus { get; set; }
        public bool EstaEnResumen { get; set; }
    }
}
