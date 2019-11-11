using GestionObra.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class ChequeEntradaModel
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public long BancoId { get; set; }
        public UsadoEn Usado { get; set; }
        public int Numero { get; set; }
        public string Serie { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public EstadoCheque Estado { get; set; }
        public string EmitidoPor { get; set; }
        public bool Descontado { get; set; }
        public decimal MontoDescontado { get; set; }
    }
}
