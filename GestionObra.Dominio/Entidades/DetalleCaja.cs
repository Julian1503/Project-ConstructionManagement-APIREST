namespace GestionObra.Dominio.Entidades
{
    using Constantes;
    public class DetalleCaja : EntityBase
    {
        public long CajaId { get; set; }
        public decimal Monto { get; set; }
        public TipoPago TipoPago { get; set; }


        //Conexiones
        public virtual Caja Caja { get; set; }
    }
}
