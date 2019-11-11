using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
    public class Proveedor : EntityBase
    {
        public string NombreFantasia { get; set; }
        public string RazonSocial { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public long? CondicionIvaId { get; set; }
        public string Cuit { get; set; }
        public string Email { get; set; }

        //Conexion
        public virtual IEnumerable<ComprobanteCompra> ComprobanteCompras { get; set; }
        public virtual CondicionIva CondicionIva { get; set; }
    }
}
