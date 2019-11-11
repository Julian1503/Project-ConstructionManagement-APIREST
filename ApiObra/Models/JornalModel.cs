using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class JornalModel
    {
        public int NumeroOrden { get; set; }
        public long ObraId { get; set; }
        public decimal Viatico { get; set; }
        public decimal Multas { get; set; }
        public decimal Gasolina { get; set; }
        public decimal Repuestos { get; set; }
        public decimal Otros { get; set; }
        public DateTime DiaJornal { get; set; }
    }
}
