namespace GestionObra.Dominio.Entidades
{
    using Constantes;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ComprobanteEntrada : EntityBase
    {
        public long UsuarioId { get; set; }
        public long? SubRubroId { get; set; }
        public decimal Monto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Interes { get; set; }
        public decimal? Cae { get; set; }
        public decimal Iva { get; set; }
        public string Detalle { get; set; }
        public UsadoEn Usado { get; set; }
        [DataType("DateTime")]
        public DateTime Fecha { get; set; }
        public int? NumeroComprobante { get; set; }
        public TipoComprobanteEntrada TipoComprobanteEntrada { get; set; }
        //Conexiones
        public virtual Usuario Usuario { get; set; }
        public virtual SubRubro SubRubro { get; set; }
    }
}
