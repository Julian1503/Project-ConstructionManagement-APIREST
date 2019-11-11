using GestionObra.Constantes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
    public class Deposito : EntityBase
    {
        public UsadoEn Usado { get; set; }
        public long BancoId { get; set; }
        public string DePara { get; set; }
        public long Numero { get; set; }
        public decimal Monto { get; set; }
        public bool Entrada { get; set; }
        public decimal ImpuestoBancario { get; set; }
        public string Concepto { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Banco Banco { get; set; }

    }
}
