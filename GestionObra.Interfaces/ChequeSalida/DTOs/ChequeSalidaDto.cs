using GestionObra.Constantes;
using GestionObra.Interfaces.Banco.DTOs;
using GestionObra.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.ChequeSalida.DTOs
{
    public class ChequeSalidaDto :DtoBase
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public UsadoEn Usado { get; set; }
        public long BancoId { get; set; }
        public int Numero { get; set; }
        public string Serie { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public virtual BancoDto Banco { get; set; }
        public string PagueseA { get; set; }
    }
}
