using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class ProveedorModel
    {
        public string NombreFantasia { get; set; }
        public string RazonSocial { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public long? CondicionIvaId { get; set; }
        public string Cuit { get; set; }
        public string Email { get; set; }
    }
}
