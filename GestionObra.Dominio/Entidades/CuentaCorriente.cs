namespace GestionObra.Dominio.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class CuentaCorriente : EntityBase
    {
        public long BancoId { get; set; }
        public long ClienteId { get; set; }
        public long ComprobanteId { get; set; }
        public decimal TotalVendido { get; set; }
        public decimal TotalCobrado { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaEmision { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaVencimiento { get; set; }

        //A cobrar es campo calculado

        //Conexiones
        public virtual Empresa Cliente { get; set; }
        public virtual Comprobante Comprobante { get; set; }
        public virtual Banco Banco { get; set; }
    }
}
