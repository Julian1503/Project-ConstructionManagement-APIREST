namespace GestionObra.Dominio.Entidades
{
    using System;
    using Constantes;
    public class Movimiento:EntityBase
    {
        public long CajaId { get; set; }
        public long UsuarioId { get; set; }
        public long ComprobanteId { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public TipoMovimiento TipoMovimento { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }


        //Conexiones
        public virtual Comprobante Comprobante { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Caja Caja { get; set; }
    }
}
