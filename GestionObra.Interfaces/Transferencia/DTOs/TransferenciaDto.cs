using GestionObra.Constantes;
using GestionObra.Interfaces.Banco.DTOs;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Empresa.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.Transferencia.DTOs
{
    public class TransferenciaDto : DtoBase
    {
        public UsadoEn Usado { get; set; }
        public long BancoId { get; set; }
        public long Numero { get; set; }
        public string PagueseA { get; set; }
        public decimal Monto { get; set; }
        public bool Entrada { get; set; }
        public decimal ImpuestoBancario { get; set; }
        public string Concepto { get; set; }
        public DateTime Fecha { get; set; }

        public virtual BancoDto Banco { get; set; }
    }
}
