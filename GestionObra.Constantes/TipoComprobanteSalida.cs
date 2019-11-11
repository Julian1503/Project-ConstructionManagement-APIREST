using System.ComponentModel;

namespace GestionObra.Constantes
{
    public enum TipoComprobanteSalida
    {
        [Description("A rendir")]
        ARendir = 1,
        [Description("Factura A")]
        A = 2,
        [Description("Factura B")]
        B = 3,
        [Description("Factura C")]
        C = 4,
        Recibo = 5,
        [Description("Nota de credito")]
        NotaCrédito = 6,
        [Description("Ticket A")]
        TicketA = 7,
        [Description("Ticket B")]
        TicketB = 8,
        [Description("Ticket C")]
        TicketC = 9,
        Ninguno = 10,
        Otro = 11,
        [Description("Factura M")]
        M = 12,
    }
}
