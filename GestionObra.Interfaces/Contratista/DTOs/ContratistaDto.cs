using GestionObra.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.Contratista.DTOs
{
   public class ContratistaDto : DtoBase
    {
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Sucursal { get; set; }
        public string Path { get; set; }
    }
}
