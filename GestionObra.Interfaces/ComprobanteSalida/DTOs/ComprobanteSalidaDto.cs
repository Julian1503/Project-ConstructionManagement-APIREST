using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.SubRubro.DTOs;

namespace GestionObra.Interfaces.ComprobanteSalida.DTOs
{
    public class ComprobanteSalidaDto : DtoBase
    {
        public long UsuarioId { get; set; }
        public long SubRubroId { get; set; }
        public SubRubroDto SubRubro { get; set; }
        public decimal Monto { get; set; }
        public UsadoEn Usado { get; set; }
        public decimal Descuento { get; set; }
        public decimal? Cae { get; set; }
        public decimal Interes { get; set; }
        public decimal Percepciones { get; set; }
        public decimal Retenciones { get; set; }
        public decimal Iva { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total => ((Monto - Descuento) + Interes) + Retenciones + Iva + Percepciones;
        public int NumeroComprobante { get; set; }
        public TipoComprobanteSalida TipoComprobanteSalida { get; set; }
    }
}
