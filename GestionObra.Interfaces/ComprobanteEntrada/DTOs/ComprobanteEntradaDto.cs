using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.SubRubro.DTOs;

namespace GestionObra.Interfaces.ComprobanteEntrada.DTOs
{
    public class ComprobanteEntradaDto : DtoBase
    {
        public SubRubroDto SubRubro { get; set; }
        public long UsuarioId { get; set; }
        public long? SubRubroId { get; set; }
        public decimal? Cae { get; set; }
        public UsadoEn Usado { get; set; }
        public decimal Monto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Interes { get; set; }
        public decimal Iva { get; set; }
        public string Detalle { get; set; }
        public decimal Total => ((Monto - Descuento) + Interes);
        public DateTime Fecha { get; set; }
        public int? NumeroComprobante { get; set; }
        public TipoComprobanteEntrada TipoComprobanteEntrada { get; set; }
    }
}
