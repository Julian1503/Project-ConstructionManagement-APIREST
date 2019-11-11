using System.ComponentModel;

namespace GestionObra.Constantes
{
    public enum TipoComprobanteEntrada
    {
        [Description("Factura A")]
        A = 1,
        [Description("Nota de debito")]
        NotaDebito = 2,
        Recibo = 3,
        Cheque = 4,
        Ninguno = 5,
        Otro = 6,
        [Description("Factura M")]
        M = 7,
    }
}
