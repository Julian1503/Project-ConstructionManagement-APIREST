namespace GestionObra.Dominio.Entidades
{
    public class DetalleComprobante:EntityBase
    {
        //Propiedades
        public long ComprobanteId { get; set; }
        public string Codigo { get; set; }
        public long MaterialId { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }

        //Conexiones
        public virtual Material Material { get; set; }
        public virtual ComprobanteCompra Comprobante { get; set; }
    }
}
