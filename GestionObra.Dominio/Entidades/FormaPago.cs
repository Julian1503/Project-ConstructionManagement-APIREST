using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;

namespace GestionObra.Dominio.Entidades
{
    public class FormaPago : EntityBase
    {
        public long ComprobanteId { get; set; }
        public TipoPago TipoFormaPago { get; set; }
        public decimal Monto { get; set; }

        //Conexion

        public virtual Comprobante Comprobante { get; set; }
    }
}
