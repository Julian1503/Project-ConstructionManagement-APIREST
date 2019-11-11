using GestionObra.Constantes;
using System;
using System.ComponentModel.DataAnnotations;

namespace GestionObra.Dominio.Entidades
{
    public class Operacion : EntityBase
    {
        public long CuentaCorrienteId { get; set; }
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public long Referencia { get; set; }
        public decimal? Descontado { get; set; }
        public string DePara { get; set; }
        public string Concepto { get; set; }
        public TipoOperacion TipoOperacion { get; set; }
        public string CodigoCausal { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? FechaEmision { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? FechaVencimiento { get; set; }
        public string ReferenciaPlus { get; set; }
        public bool EstaEnResumen { get; set; }

        public virtual CuentaCorriente CuentaCorriente { get; set; }
    }
}