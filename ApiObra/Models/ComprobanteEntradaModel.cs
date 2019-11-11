using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObra.Constantes;

namespace ApiObra.Models
{
    public class ComprobanteEntradaModel 
    {
        public decimal? Cae { get; set; }
        public long? SubRubroId { get; set; }
        public int? NumeroComprobante { get; set; }
        public DateTime Fecha { get; set; }
        public long UsuarioId { get; set; }
        public decimal Monto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Interes { get; set; }
        public decimal Iva { get; set; }
        public string Detalle { get; set; }
        public UsadoEn Usado { get; set; }
        public TipoComprobanteEntrada TipoComprobanteEntrada { get; set; }
    }
}
