namespace GestionObra.Dominio.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Comprobante : EntityBase
    {

        //Propiedades
        public int NumeroComprobante { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        public long EmpresaId { get; set; }
        public long UsuarioId { get; set; }
        public long RubroId { get; set; }
        public decimal Descuento { get; set; }
        public decimal Monto { get; set; }
        public string Detalle { get; set; }
        //Conexiones
        public virtual Usuario Usuario { get; set; }
        public virtual Rubro Rubro { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<DetalleComprobante> DetalleComprobantes { get; set; }
        public virtual ICollection<FormaPago> FormaPagos { get; set; }
        public virtual ICollection<CuentaCorriente> CuentaCorrientes { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
