using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
    public class PedidoCompra : EntityBase
    {
        public DateTime Fecha { get; set; }
        public long ProveedorId { get; set; }
        public long CodigoSolicitud { get; set; }
        public long ObraId { get; set; }
        public long SubTotal { get; set; }
        public long Descuento { get; set; }
        public long Recargos { get; set; }
        public long IVA { get; set; }
        public long Retenciones { get; set; }
        public long Percepciones { get; set; }
    }
}
