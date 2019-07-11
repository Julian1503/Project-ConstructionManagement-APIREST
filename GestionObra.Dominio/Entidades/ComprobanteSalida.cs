namespace GestionObra.Dominio.Entidades
{
    using Constantes;
    public class ComprobanteSalida : Comprobante
    {
        public Perioricidad Perioricidad { get; set; }
        public TipoComprobanteSalida TipoComprobanteSalida { get; set; }
    }
}
