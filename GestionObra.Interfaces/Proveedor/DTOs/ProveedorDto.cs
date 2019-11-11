using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.CondicionIva.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.Proveedor.DTOs
{
    public class ProveedorDto : DtoBase
    {
        public string RazonSocial { get; set; }
        public string Telefono { get; set; }
        public string NombreFantasia { get; set; }
        public string Email { get; set; }
        public string Contacto { get; set; }
        public long? CondicionIvaId { get; set; }
        public string Cuit { get; set; }

        public CondicionIvaDto CondicionIva { get; set; }
    }
}
