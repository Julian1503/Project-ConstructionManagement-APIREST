using GestionObra.Constantes;
using GestionObra.Interfaces.Banco.DTOs;
using GestionObra.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.ChequeEntrada.DTOs
{
    public class ChequeEntradaDto : DtoBase
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public long BancoId { get; set; }
        public UsadoEn Usado { get; set; }
        public int Numero { get; set; }
        public string Serie { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public virtual BancoDto Banco { get; set; }
        public EstadoCheque Estado { get; set; }
        public string EmitidoPor { get; set; }
        public bool Descontado { get; set; }
        public decimal MontoDescontado { get; set; }
    }
}
