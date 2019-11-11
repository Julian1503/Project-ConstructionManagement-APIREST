using GestionObra.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class TransferenciaModel
    {
        public UsadoEn Usado { get; set; }
        public long BancoId { get; set; }
        public string PagueseA { get; set; }
        public decimal Monto { get; set; }
        public bool Entrada { get; set; }
        public long Numero { get; set; }
        public decimal ImpuestoBancario { get; set; }
        public string Concepto { get; set; }
        public DateTime Fecha { get; set; }

    }
}
